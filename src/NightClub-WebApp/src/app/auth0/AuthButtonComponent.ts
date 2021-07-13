import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';
import { RoleService } from '../_services/role.service';

@Component({
  selector: 'app-auth-button',
  template: `
    <ng-container *ngIf="auth.isAuthenticated$ | async; else loggedOut">
      <a class="nav-link" (click)="auth.logout({ returnTo: document.location.origin })">
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
  @Output() authenticated = new EventEmitter();

  constructor(@Inject(DOCUMENT) public document: Document,
    public auth: AuthService) { }

  login() {
    this.auth.loginWithPopup({ display: 'popup' }).subscribe(
      () => {
        this.authenticated.emit();
      }
    );
  }
}
