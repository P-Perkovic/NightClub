import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from './../_services/user.service';
import { first } from 'rxjs/operators';
import { Component, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';
import { RoleService } from '../_services/role.service';
import { User } from '../_models/User';

@Component({
  selector: 'app-auth-button',
  template: `
    <ng-container *ngIf="auth.isAuthenticated$ | async; else loggedOut">
      <a class="nav-link" (click)="logout()">
        Log out
      </a>
    </ng-container>

    <ng-template #loggedOut>
      <a class="nav-link" (click)="login()">Log in</a>
    </ng-template>
  `,
  styles: [],
})
export class AuthButtonComponent {

  constructor(@Inject(DOCUMENT) public document: Document,
    public auth: AuthService,
    private roleService: RoleService,
    private userService: UserService,
    private toastr: ToastrService,
    private router: Router) { }

  login() {
    this.auth.loginWithPopup().subscribe(() => {
      this.roleService.getUserRole().subscribe(r => {
        localStorage.setItem("rola", r);
        this.auth.user$.pipe(first()).subscribe(r => {
          var user = new User();
          user.copyInto(r);
          this.userService.addUser(user).subscribe(r => {
          },
            error => {
              this.toastr.error('Problem in login proces.');
              this.logout();
            },
            () => {
              this.router.navigate([window.location.origin]);
            });
        });
      });
    });
  }

  logout() {
    localStorage.removeItem("rola");
    this.auth.logout({ returnTo: window.location.origin });
  }
}
