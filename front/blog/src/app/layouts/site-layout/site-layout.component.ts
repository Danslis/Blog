import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/service/authentication.service';


@Component({
  selector: 'app-site-layout',
  templateUrl: './site-layout.component.html',
  styleUrls: ['./site-layout.component.css']
})
export class SiteLayoutComponent implements OnInit {

  public isUserAuthenticated: boolean;
  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    this.isUserAuthenticated = this.authService.isUserAuthenticated();
  }

  logout(){
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
