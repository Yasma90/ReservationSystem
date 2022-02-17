import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReservationListComponent } from './components/reservation-list/reservation-list.component';
import { ReservationCreateComponent } from './components/reservation-create/reservation-create.component';
import { ErrorResponseComponent } from './helpers/error-response/error-response.component';
import { ContactCreateComponent } from './components/contact-create/contact-create.component';
import { HeaderPageComponent } from './components/header-page/header-page.component';
import { ContactItemComponent } from './components/contact-item/contact-item.component';
import { ReservationItemComponent } from './components/reservation-item/reservation-item.component';
import { BannerPageComponent } from './components/banner-page/banner-page.component';
import { ContactFormComponent } from './components/contact-form/contact-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ReservationListComponent,
    ReservationCreateComponent,
    ErrorResponseComponent,
    ContactCreateComponent,
    HeaderPageComponent,
    ContactItemComponent,
    ReservationItemComponent,
    BannerPageComponent,
    ContactFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    //ToastrModule.forRoot(),
    //ToastContainerModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
