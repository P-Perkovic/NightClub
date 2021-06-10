import { ArticleService } from './../../_services/article.service';
import { Article } from 'src/app/_models/Article';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

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
  @ViewChild('fileInput', { static: false }) fileInput: ElementRef;

  constructor(private articleService: ArticleService,
    private router: Router) { }

  ngOnInit() {
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
    this.articleService.addArticle(this.article)
      .subscribe(a => {
        this.router.navigate(['/home/'])
      },
        err => {
          console.log(err);
        });
  }
}
