import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginComponent } from './pages/login/login.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgSelectModule } from '@ng-select/ng-select';
import { AuthGuard } from './services/authGuard.service';
//import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatExpansionModule} from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';

// const RxJS = [LoaderInterceptor, HTTPStatus];

@NgModule({
  declarations: [AppComponent, LoginComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,

    NgSelectModule,
    BrowserAnimationsModule,
    MatExpansionModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatListModule,
    MatButtonModule,
    MatTableModule
  ],
  providers: [
    AuthGuard,
    // { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
  exports: [CommonModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {}

