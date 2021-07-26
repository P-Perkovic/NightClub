import { AdminConfig } from './../_models/AdminConfig';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdminConfigService {
  private baseUrl: string = environment.baseUrl + 'api/adminconfigs/';

  constructor(private http: HttpClient) { }

  public getAdminConfigs(): Observable<AdminConfig[]> {
    return this.http.get<AdminConfig[]>(this.baseUrl);
  }

  public getAdminConfigByKey(key: string): Observable<AdminConfig> {
    return this.http.get<AdminConfig>(this.baseUrl + key);
  }

  public updateConfig(key: string, adminConfig: AdminConfig): Observable<AdminConfig> {
    return this.http.put<AdminConfig>(this.baseUrl + key, adminConfig);
  }
}
