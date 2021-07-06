import { HomeComponent } from './home/home.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticleComponent } from './articles/article/article.component';
import { ArticleListComponent } from './articles/article-list/article-list.component';
import { UserProfileComponent } from './auth0/UserProfileComponent';
import { AuthGuard } from '@auth0/auth0-angular';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'article/new', component: ArticleComponent, canActivate: [AuthGuard] },
  { path: 'article/edit/:id', component: ArticleComponent },
  { path: 'news', component: ArticleListComponent },
  { path: 'user', component: UserProfileComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
