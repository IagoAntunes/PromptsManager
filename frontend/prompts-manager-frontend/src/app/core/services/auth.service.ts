import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginUserResponse } from 'src/app/features/auth/pages/login/response/LoginUserResponse';
import { LoginUserRequest } from 'src/app/features/auth/pages/login/request/LoginUserRequest';
import { RegisterRequest } from 'src/app/features/auth/pages/login/request/RegisterUserRequest';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuthenticated() : boolean {
    const token = this.getToken();
    return !!token;
  }
  
  private url = 'https://localhost:7207/api' + '/Auth';

  private readonly TOKEN_KEY = 'auth_token';
  private readonly EXPIRES_KEY = 'auth_expires_at';

  constructor(
    private http: HttpClient,
    private router: Router 
  ) { }

  register(request: RegisterRequest): Observable<any> {
    return this.http.post(`${this.url}/register`, request);
  }

  login(request: LoginUserRequest): Observable<LoginUserResponse> {
    return this.http.post<LoginUserResponse>(`${this.url}/login`, request);
  }

  saveToken(response: LoginUserResponse) : void {
    localStorage.setItem(this.TOKEN_KEY, response.accessToken);
    
    localStorage.setItem(this.EXPIRES_KEY, response.accessTokenExpiration);
  }

  getToken(): string | null {
    const token = localStorage.getItem(this.TOKEN_KEY);
    const expiresAt = localStorage.getItem(this.EXPIRES_KEY);

    if (!token || !expiresAt) {
      return null;
    }

    const expiresDate = new Date(expiresAt);
    const now = new Date();

    if (expiresDate < now) {
      this.logout();
      return null;
    }

    return token;
  }

  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.EXPIRES_KEY);
    
    this.router.navigate(['/auth/login']);
  }
}