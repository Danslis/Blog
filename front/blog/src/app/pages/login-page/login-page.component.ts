import { Component, OnDestroy, OnInit } from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { Subscription } from 'rxjs'
import { Router } from '@angular/router'
import { IAuthResponse } from 'src/app/interfaces/authResponse';
import { AuthenticationService } from 'src/app/service/authentication.service';



@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit, OnDestroy {

  form: FormGroup;
  aSub: Subscription;
  isAuth:boolean;

  constructor(
    private auth: AuthenticationService,
    private router: Router) {
  }

  ngOnInit() {
    this.isAuth = this.auth.isUserAuthenticated();
    if (this.isAuth) {
     this.router.navigate(['/home']);
    }
    this.form = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(5)])
    });
  }

  ngOnDestroy() {
    if (this.aSub) {
      this.aSub.unsubscribe();
    }
  }

  onSubmit() {
    this.form.disable();
    this.aSub = this.auth.login(this.form.value).subscribe(
    (response: IAuthResponse) => {
      const token = response.token;
      localStorage.setItem("token", token);
      this.router.navigate(['/home']);
    },
    error => {
        this.form.enable();
     }
    );
  }

}
