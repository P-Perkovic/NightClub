import { ReservationService } from './_services/reservation.service';
import { GlobalApp } from './GlobalApp';
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
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Auth0Interceptor } from './_interceptors/auth0.interceptor';
import { ReservTableComponent } from './reserv-table/reserv-table.component';
import { IdentityGuardService } from './_services/identity-guard.service';
import { IdentityService } from './_services/identity.service';
import { UserProfileComponent } from './auth0/user-profile/user-profile.component';
import { ReservData } from './ConfigData';
import { TablesComponent } from './tables/tables.component';

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
    UserProfileComponent,
    ReservTableComponent,
    TablesComponent
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
      domain: environment.auth.domain,
      clientId: environment.auth.clientId,
      audience: environment.auth.audience
    }),
  ],
  providers: [
    TableService,
    ConfirmationDialogService,
    GlobalApp,
    ReservData,
    ArticleService,
    IdentityGuardService,
    ReservationService,
    IdentityService,
    { provide: HTTP_INTERCEPTORS, useClass: Auth0Interceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
