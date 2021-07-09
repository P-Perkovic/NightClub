import { RoleService } from 'src/app/_services/role.service';
import { ArticleService } from './../_services/article.service';
import { Component, OnInit } from '@angular/core';
import { Article } from '../_models/Article';
import { Role } from '../_models/Role';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  articles: Article[];
  constructor(private articleService: ArticleService,
    public roleService: RoleService) {
    this.roleService.getUserRole().subscribe(r => {
      Role.role = r;
    });
  }

  ngOnInit() {
    this.articleService.getArticles()
      .subscribe(a => {
        this.articles = a.slice(0, 3);
      });
  }
}
