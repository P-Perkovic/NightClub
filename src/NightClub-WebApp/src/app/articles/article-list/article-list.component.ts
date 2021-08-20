import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from './../../_services/confirmation-dialog.service';
import { Router } from '@angular/router';
import { ArticleService } from './../../_services/article.service';
import { Component, OnInit } from '@angular/core';
import { Article } from 'src/app/_models/Article';
import { GlobalApp } from 'src/app/GlobalApp';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {
  articles: Article[];
  rola: string = null;

  constructor(private _articleService: ArticleService,
    private _router: Router,
    private _confirmationDialogService: ConfirmationDialogService,
    private _toastr: ToastrService,
    public app: GlobalApp) { }

  ngOnInit(): void {
    this._articleService.getArticles()
      .subscribe(a => {
        this.articles = a;
      },
        error => {
          this._toastr.error(GlobalApp.ServerError);
        });
  }

  delete(id: number) {
    this._confirmationDialogService.confirm('Atention', 'Do you really want to delete this article?')
      .then(() =>
        this._articleService.deleteArticle(id).subscribe(r => {
          this._toastr.success('The article has been deleted.');
          this.removeDeletedArticle(id);
        },
          error => {
            this._toastr.error('Failed to delete the article.');
          }))
      .catch(() => '');
  }

  removeDeletedArticle(id: number) {
    this.articles = this.articles.filter(a => a.id != id);
  }

  edit(id: number) {
    this._router.navigate(['/article/edit/' + id]);
  }

  showReservBtn(eventDate: Date) {
    var dateNow = new Date();
    dateNow = new Date(dateNow.toDateString());
    var date = new Date(eventDate);
    if (dateNow <= date)
      return true;

    return false;
  }
}
