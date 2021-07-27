import { Router } from '@angular/router';
import { GlobalApp } from 'src/app/GlobalApp';
import { ToastrService } from 'ngx-toastr';
import { ArticleService } from './../_services/article.service';
import { Component, OnInit } from '@angular/core';
import { Article } from '../_models/Article';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  rola: string = null;
  articles: Article[];

  constructor(private _articleService: ArticleService,
    private _toastr: ToastrService,
    private _router: Router) {
  }

  ngOnInit(): void {
    this._articleService.getArticles()
      .subscribe(a => {
        this.articles = a.slice(0, 3);
      },
        error => {
          this._toastr.error(GlobalApp.ServerError);
        });
  }

  toArticle(id: string) {
    this._router.navigate(['/news/']);
    setTimeout(() => {
      window.scrollTo($('#' + id).position())
    }, 500);
  }
}
