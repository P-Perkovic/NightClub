import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl: string = environment.baseUrl + 'api/users/';

  constructor(private http: HttpClient) { }

  public addUser(user: User) {
    return this.http.post(this.baseUrl, user);
  }

  public getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }

  public getUserById(id: string): Observable<User> {
    return this.http.get<User>(this.baseUrl + id);
  }
}
