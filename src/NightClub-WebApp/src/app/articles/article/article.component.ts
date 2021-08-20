import { ArticleService } from './../../_services/article.service';
import { Article } from 'src/app/_models/Article';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GlobalApp } from 'src/app/GlobalApp';
import { NgModel } from '@angular/forms';

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
    photoURL: "#",
    eventDate: null
  }
  fileName: string = 'Choose image';
  fileBtn: string = this.fileName;
  isImageInputInvalid: boolean = true;
  isImageInputClicked: boolean = false;
  header: string = 'New';
  isDateValid = false;
  isDateClicked = false;
  @ViewChild('fileInput', { static: false }) fileInput: ElementRef;

  constructor(private _articleService: ArticleService,
    private _router: Router,
    private _route: ActivatedRoute,
    private _toastr: ToastrService) {

    this._route.params.subscribe(p => {
      this.article.id = +p['id'] || 0;
    });
    if (this.article.id != 0) {
      this.header = 'Edit';
      this.fileBtn = 'Replace image';
      this.fileName = 'Replace image';
      this.isImageInputInvalid = false;
    }
  }

  ngOnInit(): void {
    if (this.article.id != 0) {
      this._articleService.getArticleById(this.article.id)
        .subscribe(a => {
          this.article = a;
        },
          error => {
            this._toastr.error(GlobalApp.ServerError);
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
      this._articleService.addArticle(this.article)
        .subscribe(() => {
          this._toastr.success('The article has been added.');
          this._router.navigate(['/news/']);
        },
          error => {
            this._toastr.error('Failed to add the article.');
          })
    }
    else {
      this._articleService.updateArticle(this.article.id, this.article)
        .subscribe(() => {
          this._toastr.success('The article has been updated.');
          this._router.navigate(['/news/']);
        },
          error => {
            this._toastr.error('Failed to update the article.');
          })
    }
  }
  setDate(model: NgModel) {
    if (!model.valid) {
      return;
    }
    this.isDateValid = true;
    this.article.eventDate = new Date(model.value.year, model.value.month - 1, model.value.day);
  }

  dateClick() {
    this.isDateClicked = true;
  }
}
