import { IdentityService } from '../_services/identity.service';
import { Component, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

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
    public identity: IdentityService,
    private auth: AuthService) { }

  login() {
    this.identity.loginWithAuthentication();
  }

  logout() {
    this.identity.logout();
  }
}
