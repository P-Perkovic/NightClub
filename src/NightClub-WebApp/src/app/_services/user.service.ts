import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private _baseUrl: string = environment.baseUrl + 'api/users/';

  constructor(private _http: HttpClient) { }

  public addUser(user: User) {
    return this._http.post(this._baseUrl, user);
  }

  public getAll(): Observable<User[]> {
    return this._http.get<User[]>(this._baseUrl);
  }

  public getUserById(id: string): Observable<User> {
    return this._http.get<User>(this._baseUrl + id);
  }
}
