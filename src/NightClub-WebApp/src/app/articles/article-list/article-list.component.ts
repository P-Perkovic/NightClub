import { ArticleService } from './../../_services/article.service';
import { Component, OnInit } from '@angular/core';
import { Article } from 'src/app/_models/Article';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {
  articles: Article[];

  constructor(private articleService: ArticleService) { }

  ngOnInit() {
    this.articleService.getArticles()
      .subscribe(a => {
        this.articles = a;
      });
  }



  delete(id: number) {
    this.articleService.deleteArticle(id)
      .subscribe(r => {
        this.articles.filter(a => a.id == id);
      });
  }
}
