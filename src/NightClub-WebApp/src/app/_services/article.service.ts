import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Article } from './../_models/Article';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private url: string = environment.baseUrl + 'api/articles/';

  constructor(private http: HttpClient) { }

  public getArticles(): Observable<Article[]> {
    return this.http.get<Article[]>(this.url);
  }

  public getArticleById(id: number): Observable<Article> {
    return this.http.get<Article>(this.url + id);
  }

  public addArticle(article: Article) {
    return this.http.post(this.url, article);
  }

  public updateArticle(id: number, article: Article) {
    return this.http.put(this.url + id, article);
  }

  public deleteArticle(id: number) {
    return this.http.delete(this.url + id);
  }
}
