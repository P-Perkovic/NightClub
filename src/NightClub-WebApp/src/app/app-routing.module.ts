import { IdentityGuardService } from './_services/identity-guard.service';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticleComponent } from './articles/article/article.component';
import { ArticleListComponent } from './articles/article-list/article-list.component';
import { ReservTableComponent } from './reservation/reserv-table/reserv-table.component';
import { UserProfileComponent } from './auth0/user-profile/user-profile.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'article/new', component: ArticleComponent, canActivate: [IdentityGuardService] },
  { path: 'article/edit/:id', component: ArticleComponent, canActivate: [IdentityGuardService] },
  { path: 'news', component: ArticleListComponent },
  { path: 'user', component: UserProfileComponent, canActivate: [IdentityGuardService] },
  { path: 'reserv-table', component: ReservTableComponent, canActivate: [IdentityGuardService] },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
