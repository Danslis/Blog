import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { SiteLayoutComponent } from './layouts/site-layout/site-layout.component';
import { CreatePostPageComponent } from './pages/create-post-page/create-post-page.component';
import { EditPostPageComponent } from './pages/edit-post-page/edit-post-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { PostPageComponent } from './pages/post-page/post-page.component';
import { AuthGuard } from './shared/classes/auth.guard';



const routes: Routes = [
  {
    path: '', component: AuthLayoutComponent, children: [
      {path: '', redirectTo: '/login', pathMatch: 'full'},
      {path: 'login', component: LoginPageComponent}
    ]
  },
  {
    path: '', component: SiteLayoutComponent,  canActivate: [AuthGuard], children: [
      {path: 'home', component: HomePageComponent},
      {path: 'post/:id', component: PostPageComponent},
      {path: 'add-post', component: CreatePostPageComponent},
      {path: 'edit-post/:id', component: EditPostPageComponent},
    ]
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


 }
