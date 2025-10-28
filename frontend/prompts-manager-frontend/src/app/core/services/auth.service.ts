import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterRequest } from 'src/app/features/auth/pages/login/request/RegisterUserRequest';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly http = inject(HttpClient);
  private readonly url = 'https://localhost:7207/Auth/';

  isAuthenticated() : boolean{
    return false;
  }
  getToken() {
    return null;
  }

  register(request:RegisterRequest) : Observable<any>{
    return this.http.post(`${this.url}/register`, request);
  }


  constructor() { }
}
