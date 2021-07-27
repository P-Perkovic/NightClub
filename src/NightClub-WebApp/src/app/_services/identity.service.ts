import { GlobalApp } from 'src/app/GlobalApp';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from './user.service';
import { AuthService } from '@auth0/auth0-angular';
import { Injectable } from '@angular/core';
import { first, map } from 'rxjs/operators';
import { DecodedToken } from '../_models/DecodedToken';
import jwt_decode from "jwt-decode";
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {

  constructor(private _auth: AuthService,
    private _userService: UserService,
    private _toastr: ToastrService,
    private _router: Router) { }

  loginWithAuthentication(stateUrl: string = null) {
    this._auth.loginWithPopup().subscribe(() => {
      this._auth.getAccessTokenSilently().pipe(
        map(t => jwt_decode<DecodedToken>(t))).subscribe(r => {
          localStorage.setItem(GlobalApp.Rola, r.permissions[0]);
          this._auth.user$.pipe(first()).subscribe(r => {
            var user = new User();
            user.copyInto(r);
            this._userService.addUser(user).subscribe(r => {
              localStorage.setItem(GlobalApp.IsAuthenticated, GlobalApp.True);
              if (stateUrl) {
                this._router.navigate([stateUrl]);
              }
            },
              error => {
                this._toastr.error('Problem in login proces.');
                this.logout();
              });
          });
        });
    });
  }

  logout() {
    localStorage.removeItem(GlobalApp.IsAuthenticated);
    localStorage.removeItem(GlobalApp.Rola);
    this._router.navigate(['/home/']);
    this._auth.logout();
  }
}