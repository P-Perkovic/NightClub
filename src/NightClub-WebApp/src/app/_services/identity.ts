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

  constructor(private auth: AuthService,
    private userService: UserService,
    private toastr: ToastrService,
    private router: Router) { }

  loginWithAuthentication(stateUrl: string = null) {
    this.auth.loginWithPopup().subscribe(() => {
      this.auth.getAccessTokenSilently().pipe(
        map(t => jwt_decode<DecodedToken>(t).permissions[0])).subscribe(r => {
          localStorage.setItem(GlobalApp.Rola, r);
          this.auth.user$.pipe(first()).subscribe(r => {
            var user = new User();
            user.copyInto(r);
            this.userService.addUser(user).subscribe(r => {
              localStorage.setItem(GlobalApp.IsAuthenticated, GlobalApp.True);
              if (stateUrl) {
                this.router.navigate([stateUrl]);
              }
            },
              error => {
                this.toastr.error('Problem in login proces.');
                this.logout();
              });
          });
        });
    });
  }

  logout() {
    localStorage.removeItem(GlobalApp.Rola);
    localStorage.removeItem(GlobalApp.IsAuthenticated);
    this.auth.logout();
  }
}