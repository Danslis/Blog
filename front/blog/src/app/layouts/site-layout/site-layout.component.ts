import { Component, OnInit, AfterViewInit } from '@angular/core';


@Component({
  selector: 'app-site-layout',
  templateUrl: './site-layout.component.html',
  styleUrls: ['./site-layout.component.css']
})
export class SiteLayoutComponent implements OnInit, AfterViewInit {

  constructor() { }

  ngOnInit(): void {
    }


  loadUserInfo() {
  }

  ngAfterViewInit(): void {
  }

  logout(event: Event){

  }
}
