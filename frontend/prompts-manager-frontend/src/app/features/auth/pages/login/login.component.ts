import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router } from '@angular/router';
import { RegisterRequest } from './request/RegisterUserRequest';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  isLogin = true;
  loginForm: FormGroup;
  registerForm: FormGroup;
  
  isLoading = false;
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    // FORM DE LOGIN
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });

    // FORM DE REGISTRO (com 'confirmPassword' e validador customizado)
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]]
    }, {
      validators: this.passwordMatchValidator
    });
  }

  // Validador para garantir que as senhas são iguais
  private passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');
    if (!password || !confirmPassword) {
      return null;
    }
    return password.value === confirmPassword.value ? null : { passwordMismatch: true };
  }

  toggleForm(): void {
    this.isLogin = !this.isLogin;
    this.loginForm.reset();
    this.registerForm.reset();
    this.errorMessage = null; // Limpa erros ao trocar
  }

  onSubmit(): void {
    this.isLoading = true;
    this.errorMessage = null;

    if (this.isLogin) {
      // --- LÓGICA DE LOGIN ---
      if (this.loginForm.invalid) {
        this.loginForm.markAllAsTouched();
        this.logFormValidationErrors(this.loginForm, 'Login'); // Debug
        this.errorMessage = "Por favor, corrija os campos.";
        this.isLoading = false;
        return;
      }

      // const request: LoginRequest = this.loginForm.value;
      // this.authService.login(request).subscribe({
      //   next: (response) => {
      //     this.isLoading = false;
      //     // Salve o token (no service)
      //     this.router.navigate(['/home']); // Redireciona
      //   },
      //   error: (err) => {
      //     this.isLoading = false;
      //     this.errorMessage = "E-mail ou senha inválidos.";
      //   }
      // });

    } else {
      // --- LÓGICA DE REGISTRO ---
      if (this.registerForm.invalid) {
        this.registerForm.markAllAsTouched();
        this.logFormValidationErrors(this.registerForm, 'Register'); // Debug
        this.errorMessage = "Por favor, corrija os campos.";
        this.isLoading = false;
        return;
      }

      const request: RegisterRequest = {
        email: this.registerForm.value.email,
        password: this.registerForm.value.password
      };
      
      this.authService.register(request).subscribe({
        next: () => {
          this.isLoading = false;
          this.errorMessage = "Conta criada com sucesso! Faça o login.";
          this.toggleForm(); // Volta para a tela de login
        },
        error: (err) => {
          this.isLoading = false;
          this.errorMessage = "Este e-mail já está em uso.";
        }
      });
    }
  }

  // Função de Debug
  private logFormValidationErrors(form: FormGroup, formName: string) {
    console.log(`--- ERROS DE VALIDAÇÃO [${formName}] ---`);
    Object.keys(form.controls).forEach(key => {
      const control = form.get(key);
      if (control && control.invalid) {
        console.log(`Campo: '${key}', Erros:`, control.errors);
      }
    });
    console.log('-----------------------------------');
  }
}