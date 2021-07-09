import { DecodedToken } from './../_models/DecodedToken';
import { mergeMap, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private auth: AuthService) { }

  public getUserRole() {
    return this.auth.getAccessTokenSilently().pipe(
      map(t => jwt_decode<DecodedToken>(t).permissions[0])
    )
  }
}
