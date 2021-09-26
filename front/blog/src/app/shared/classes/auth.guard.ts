import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthenticationService, private _router: Router){}
  canActivate() {
    if (this.authService.isUserAuthenticated()) {
      return true;
    }
    this._router.navigate(['/login']);
    return false;
  }

}
