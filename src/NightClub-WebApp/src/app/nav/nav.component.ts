import { GlobalApp } from './../GlobalApp';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  user: any;

  constructor(public auth: AuthService,
    public app: GlobalApp) { }

  ngOnInit(): void {
    this.auth.user$.subscribe(r => {
      this.user = r;
    },
      error => {
        localStorage.setItem(GlobalApp.IsAuthenticated, 'false');
      });
  }
}
