import { ArticleService } from './_services/article.service';
import { ConfirmationDialogService } from './_services/confirmation-dialog.service';
import { CategoryService } from './_services/category.service';
import { TableService } from './_services/table.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    TableService,
    CategoryService,
    ConfirmationDialogService,
    ArticleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
