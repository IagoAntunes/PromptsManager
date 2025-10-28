import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  if (authService.isAuthenticated()) { // Você precisará implementar essa lógica
    return true;
  }

  // Não está logado, redireciona para o login
  router.navigate(['/auth/login']);
  return false;
};