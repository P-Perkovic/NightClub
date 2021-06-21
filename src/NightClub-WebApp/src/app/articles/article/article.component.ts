import { ArticleService } from './../../_services/article.service';
import { Article } from 'src/app/_models/Article';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  article: Article = {
    id: 0,
    title: '',
    content: '',
    publishingDate: null,
    photoFilePath: '',
    photoURL: "#"
  }
  fileName: string = 'Choose image';
  fileBtn: string = this.fileName;
  isImageInputInvalid: boolean = true;
  isImageInputClicked: boolean = false;
  header: string = 'New';
  @ViewChild('fileInput', { static: false }) fileInput: ElementRef;

  constructor(private articleService: ArticleService,
    private router: Router,
    private route: ActivatedRoute) {

    this.route.params.subscribe(p => {
      this.article.id = +p['id'] || 0;
    });
    if (this.article.id != 0) {
      this.header = 'Edit';
      this.fileBtn = 'Replace image';
      this.fileName = 'Replace image';
      this.isImageInputInvalid = false;
    }
  }

  ngOnInit() {
    if (this.article.id != 0) {
      this.articleService.getArticleById(this.article.id)
        .subscribe(a => {
          this.article = a;
        });
    }
  }

  uploadPhoto() {
    var files: HTMLInputElement = this.fileInput.nativeElement.files;
    var reader = new FileReader();
    this.fileName = files[0].name;
    this.fileBtn = 'Replace image'
    this.isImageInputInvalid = false;
    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      this.article.photoURL = reader.result;
    }
  }

  uploadClick() {
    this.isImageInputClicked = true;
  }

  save() {
    if (this.article.id == 0) {
      this.articleService.addArticle(this.article)
        .subscribe(a => {
          this.router.navigate(['/news/']);
        },
          err => {
            console.log(err);
          });
    }
    else {
      this.articleService.updateArticle(this.article.id, this.article)
        .subscribe(a => {
          this.router.navigate(['/news/']);
        },
          err => {
            console.log(err);
          });
    }
  }
}
