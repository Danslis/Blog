import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { SiteLayoutComponent } from './layouts/site-layout/site-layout.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { JwtModule } from "@auth0/angular-jwt";
import { PostComponent } from './shared/components/post/post.component';
import { PostPageComponent } from './pages/post-page/post-page.component';
import { QuillModule } from 'ngx-quill';
import { CreatePostPageComponent } from './pages/create-post-page/create-post-page.component';
import { EditPostPageComponent } from './pages/edit-post-page/edit-post-page.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    AuthLayoutComponent,
    SiteLayoutComponent,
    LoginPageComponent,
    HomePageComponent,
    PostPageComponent,
    PostComponent,
    CreatePostPageComponent,
    EditPostPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    QuillModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5000","localhost:5001"],
        blacklistedRoutes: []
      }
    })
  ],
  exports: [
    QuillModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
