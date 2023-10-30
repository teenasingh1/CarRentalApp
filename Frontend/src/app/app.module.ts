import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/user/home/home.component';
import { ForbiddenPageComponent } from './components/global/forbidden-page/forbidden-page.component';
import { NavbarComponent } from './components/global/navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './components/global/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { CarDetailsComponent } from './components/user/car-details/car-details.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { EditAgreementComponent } from './components/admin/edit-agreement/edit-agreement.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { UserBookingsComponent } from './components/user/user-bookings/user-bookings.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ForbiddenPageComponent,
    NavbarComponent,
    LoginComponent,
    CarDetailsComponent,
    DashboardComponent,
    EditAgreementComponent,
    UserBookingsComponent
  ],
  imports: [
    RouterModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
