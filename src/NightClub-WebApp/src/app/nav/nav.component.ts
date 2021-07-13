import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { RoleService } from '../_services/role.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public auth: AuthService,
    public roleService: RoleService) { }

  ngOnInit() {
  }

  authenticatedEvent() {
    debugger
    this.roleService.getUserRole().subscribe(r => {
      localStorage.setItem("rola", r);
    });
  }
}
