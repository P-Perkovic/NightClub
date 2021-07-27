import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Article } from '../_models/Article';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private _baseUrl: string = environment.baseUrl + 'api/articles/';

  constructor(private _http: HttpClient) { }

  public addArticle(article: Article) {
    return this._http.post(this._baseUrl, article);
  }

  public updateArticle(id: number, article: Article) {
    return this._http.put(this._baseUrl + id, article);
  }

  public getArticles(): Observable<Article[]> {
    return this._http.get<Article[]>(this._baseUrl);
  }

  public deleteArticle(id: number) {
    return this._http.delete(this._baseUrl + id);
  }

  public getArticleById(id: number): Observable<Article> {
    return this._http.get<Article>(this._baseUrl + id);
  }
}
