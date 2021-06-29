import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ArticleService } from './_services/article.service';
import { ConfirmationDialogService } from './_services/confirmation-dialog.service';
import { TableService } from './_services/table.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ArticleComponent } from './articles/article/article.component';
import { ArticleListComponent } from './articles/article-list/article-list.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { NgbdDatepickerPopup } from './datepicker/datepicker-popup';
import { FooterComponent } from './footer/footer.component';
import { AuthModule } from '@auth0/auth0-angular';
import { AuthButtonComponent } from './auth0/AuthButtonComponent';
import { UserProfileComponent } from './auth0/UserProfileComponent';

@NgModule({
  declarations: [
    AppComponent,
    ArticleComponent,
    ArticleListComponent,
    HomeComponent,
    NavComponent,
    ConfirmationDialogComponent,
    NgbdDatepickerPopup,
    FooterComponent,
    AuthButtonComponent,
    UserProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgbModule,
    ToastrModule.forRoot(),
    AuthModule.forRoot({
      domain: 'vegapperko.eu.auth0.com',
      clientId: 'syzviMv8FkjVOzf0U7yQeNkfDK5IloxM'
    }),
  ],
  providers: [
    TableService,
    ConfirmationDialogService,
    ArticleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
