import { Table } from './../_models/Table';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TableService {
  private baseUrl: string = environment.baseUrl + 'api/tables/';

  constructor(private http: HttpClient) { }

  public getTables(): Observable<Table[]> {
    return this.http.get<Table[]>(this.baseUrl);
  }
}
