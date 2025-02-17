import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '../models/login-request';
import { Observable, tap } from 'rxjs';
import { LoginResponse } from '../models/login-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>('/login', credentials)
      .pipe(tap((response: LoginResponse) => {
        localStorage.setItem('accessToken', response.accessToken);
        document.cookie = `refreshToken=${response.refreshToken}`;
      }));
  }

  refreshToken(): Observable<LoginResponse> {
    const refreshToken = this.getRefreshTokenFromCookie();

    return this.httpClient.post<LoginResponse>('/refresh', { refreshToken })
      .pipe(tap((response: LoginResponse) => {
        localStorage.setItem('accessToken', response.accessToken);
        document.cookie = `refreshToken=${response.refreshToken}`;
      }));
  }


  private getRefreshTokenFromCookie(): string | null {
    const cookies = document.cookie;
    const cookiesArray = cookies.split('; ');
    const refreshTokenCookie = cookiesArray.find((cookie) => cookie.includes('refreshToken'));
    return refreshTokenCookie?.split('=')[1] ?? null;
  }

  logout(): void {
    localStorage.removeItem('accessToken');
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('accessToken') !== null;
  }
}
