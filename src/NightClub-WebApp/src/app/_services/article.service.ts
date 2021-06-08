import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Article } from '../_models/Article';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private baseUrl: string = environment.baseUrl + 'api/articles/';

  constructor(private http: HttpClient) { }

  public addArticle(article: Article) {
    return this.http.post(this.baseUrl, article);
  }

  public updateArticle(id: number, article: Article) {
    return this.http.put(this.baseUrl + id, article);
  }

  public getArticles(): Observable<Article[]> {
    return this.http.get<Article[]>(this.baseUrl);
  }

  public deleteCArticle(id: number) {
    return this.http.delete(this.baseUrl + id);
  }

  public getArticleById(id): Observable<Article> {
    return this.http.get<Article>(this.baseUrl + id);
  }
}
