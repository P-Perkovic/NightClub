import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from './../../_services/confirmation-dialog.service';
import { Router } from '@angular/router';
import { ArticleService } from './../../_services/article.service';
import { Component, OnInit } from '@angular/core';
import { Article } from 'src/app/_models/Article';
import { AuthService } from '@auth0/auth0-angular';
import { RoleService } from 'src/app/_services/role.service';
import { Role } from 'src/app/_models/Role';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {
  articles: Article[];
  role: string;

  constructor(private articleService: ArticleService,
    private router: Router,
    private confirmationDialogService: ConfirmationDialogService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.role = Role.role;
    console.log(this.role);
    this.articleService.getArticles()
      .subscribe(a => {
        this.articles = a;
      });
  }

  delete(id: number) {
    this.confirmationDialogService.confirm('Atention', 'Do you really want to delete this article?')
      .then(() =>
        this.articleService.deleteArticle(id).subscribe(r => {
          this.toastr.success('The article has been deleted.');
          this.removeDeletedArticle(id);
        },
          error => {
            this.toastr.error('Failed to delete the article.');
          }))
      .catch(() => '');
  }

  removeDeletedArticle(id: number) {
    this.articles = this.articles.filter(a => a.id != id);
  }

  edit(id: number) {
    this.router.navigate(['/article/edit/' + id]);
  }
}
