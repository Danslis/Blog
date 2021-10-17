import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthResponse } from '../interfaces/authResponse';
import { UserLoginRequest } from '../interfaces/userLoginRequest';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {
   }

  public login(userLoginRequest: UserLoginRequest): Observable<IAuthResponse> {
    return this.http.post<IAuthResponse>(`${environment.url}/auth/login/`, userLoginRequest)
  }
  public logout = () => {
    localStorage.removeItem("token");
  }

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
    return token && !this.jwtHelper.isTokenExpired(token);
  }

}
