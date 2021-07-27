import { AdminConfig } from './../_models/AdminConfig';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdminConfigService {
  private _baseUrl: string = environment.baseUrl + 'api/adminconfigs/';

  constructor(private _http: HttpClient) { }

  public getAdminConfigs(): Observable<AdminConfig[]> {
    return this._http.get<AdminConfig[]>(this._baseUrl);
  }

  public getAdminConfigByKey(key: string): Observable<AdminConfig> {
    return this._http.get<AdminConfig>(this._baseUrl + key);
  }

  public updateConfig(key: string, adminConfig: AdminConfig): Observable<AdminConfig> {
    return this._http.put<AdminConfig>(this._baseUrl + key, adminConfig);
  }
}
