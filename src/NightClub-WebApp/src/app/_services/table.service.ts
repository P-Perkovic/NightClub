import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Table } from '../_models/Table';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TableService {
  private url: string = environment.baseUrl + 'api/tables/';

  constructor(private http: HttpClient) { }

  public getTables(): Observable<Table[]> {
    return this.http.get<Table[]>(this.url);
  }
}
