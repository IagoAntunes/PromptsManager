import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router } from '@angular/router';
import { take, finalize } from 'rxjs/operators';
import { LoginUserRequest } from './request/LoginUserRequest';
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
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });

    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  toggleForm(): void {
    this.isLogin = !this.isLogin;
    this.loginForm.reset();
    this.registerForm.reset();
    this.errorMessage = null;
  }

  onSubmit(): void {
    this.isLoading = true;
    this.errorMessage = null;

    if (this.isLogin) {
      this._handleLogin();
    } else {
      this._handleRegister();
    }
  }

  private _handleLogin(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      this.errorMessage = "Por favor, corrija os campos.";
      this.isLoading = false;
      return;
    }

    const request: LoginUserRequest = this.loginForm.value;

    this.authService.login(request).pipe(
      take(1),
      finalize(() => this.isLoading = false)
    ).subscribe({
      next: (response) => {
        this.authService.saveToken(response);
        this.router.navigate(['/home']);
      },
      error: (err) => {
        console.error('Erro no login:', err);
        this.errorMessage = "E-mail ou senha inválidos.";
      }
    });
  }

  private _handleRegister(): void {
    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      this._logFormValidationErrors(this.registerForm, 'Register');
      this.errorMessage = "Por favor, corrija os campos.";
      this.isLoading = false;
      return;
    }

    const request: RegisterRequest = this.registerForm.value;

    this.authService.register(request).pipe(
      take(1),
      finalize(() => this.isLoading = false)
    ).subscribe({
      next: () => {
        this.errorMessage = "Conta criada com sucesso! Faça o login.";
        this.toggleForm();
      },
      error: (err) => {
        console.error('Erro no registro:', err);
        this.errorMessage = err.status === 400 || err.status === 409
          ? "Este e-mail já está em uso."
          : "Erro inesperado no servidor. Tente novamente.";
      }
    });
  }

  private _logFormValidationErrors(form: FormGroup, formName: string) {
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