import { ArticleService } from './../../_services/article.service';
import { Article } from 'src/app/_models/Article';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

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
    photoURL: '#'
  }
  fileName: string = 'Choose image';
  fileBtn: string = this.fileName;
  isImageInputInvalid: boolean = true;
  isImageInputClicked: boolean = false;
  constructor(private articleService: ArticleService) { }

  ngOnInit() {
  }

  uploadPhoto(files) {
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

  submit() {
    this.articleService.addArticle(this.article)
      .subscribe(a => console.log(a));
  }
}
