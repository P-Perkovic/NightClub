import { Component } from '@angular/core';
import { AuthClientConfig, AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-user-profile',
  template: `
    <div class='py-4 mx-4' *ngIf="auth.user$ | async as user">
    <div class="row align-items-center profile-header">
      <div class="col-md-2 mb-3 text-center">
        <img
          [src]="user.picture"
          alt="User's profile picture"
          class="rounded-circle img-fluid profile-picture"
        />
      </div>
      <div class="col-md text-center text-md-left">
        <h2>{{ user.name }}</h2>
        <p class="lead text-muted">{{ user.email }}</p>
      </div>
    </div>`
})
export class UserProfileComponent {
  profileJson: string = null;

  constructor(public auth: AuthService,
    private authConfig: AuthClientConfig) {
  }
}