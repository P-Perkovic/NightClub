import { IdentityService } from './identity.service';
import { ToastrService } from 'ngx-toastr';
import { GlobalApp } from '../GlobalApp';
import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';


@Injectable()
export class IdentityGuardService implements CanActivate {

  constructor(private _app: GlobalApp,
    private _router: Router,
    private _toastr: ToastrService,
    private _identity: IdentityService,) {
  }

  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (this._app.isAuthenticated() == false) {
      this._identity.loginWithAuthentication(state.url);
      return false;
    }

    if ((route.routeConfig.path == "article/new" || route.routeConfig.path == "article/edit/:id")
      && this._app.getRole() != GlobalApp.Admin) {
      this._toastr.warning('You are not allowed to view this page. You are redirected to news Page');
      this._router.navigate(['/news/']);

      return false;
    }
    return true;
  }

}