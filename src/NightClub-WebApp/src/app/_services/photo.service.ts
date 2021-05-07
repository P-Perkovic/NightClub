import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  private url: string = environment.baseUrl + "api/";

  constructor(private http: HttpClient) { }

  uploadPhoto(articleId: number, photo: any) {
    var formData = new FormData();
    formData.append('file', photo);
    return this.http.post(this.url + `${articleId}/photos/`, formData);
  }

  deletePhoto(articleId: number) {
    return this.http.delete(this.url + `${articleId}/photos/`);
  }
}
