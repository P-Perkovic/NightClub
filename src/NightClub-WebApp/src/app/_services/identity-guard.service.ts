import { IdentityService } from './identity';
import { ToastrService } from 'ngx-toastr';
import { GlobalApp } from '../GlobalApp';
import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';


@Injectable()
export class IdentityGuardService implements CanActivate {

  constructor(private app: GlobalApp,
    private router: Router,
    private toastr: ToastrService,
    private identity: IdentityService,) {
  }

  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (this.app.isAuthenticated() == false) {
      this.identity.loginWithAuthentication(state.url);
      return false;
    }

    if ((route.routeConfig.path == "article/new" || route.routeConfig.path == "article/edit/:id")
      && this.app.getRole() != GlobalApp.Admin) {
      this.toastr.warning('You are not allowed to view this page. You are redirected to news Page');
      this.router.navigate(['/news/']);

      return false;
    }
    return true;
  }

}