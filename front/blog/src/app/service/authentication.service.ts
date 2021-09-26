import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, Subject } from 'rxjs';
import { IAuthResponse } from '../interfaces/authResponse';
import { UserLoginRequest } from '../interfaces/userLoginRequest';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseUrl: string;

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {
    this.baseUrl = "http://localhost:5000";
   }

  public login(userLoginRequest: UserLoginRequest): Observable<IAuthResponse> {
    return this.http.post<IAuthResponse>(`${this.baseUrl}/auth/login/`, userLoginRequest)
  }
  public logout = () => {
    localStorage.removeItem("token");
  }

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
    return token && !this.jwtHelper.isTokenExpired(token);
  }

}
