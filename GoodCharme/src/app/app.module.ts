import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './components/register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { SanPhamChiTietComponent } from './components/san-pham-chi-tiet/san-pham-chi-tiet.component';
import { SanPhamDanhMucComponent } from './components/san-pham-danh-muc/san-pham-danh-muc.component';
import { CartComponent } from './components/cart/cart.component';
import { OrderComponent } from './components/order/order.component';
import { OrderTrackingComponent } from './components/order-tracking/order-tracking.component';
import { ContactComponent } from './components/contact/contact.component';
import { Page404Component } from './components/page-404/page-404.component';
import { AccountComponent } from './components/account/account.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    AboutComponent,
    LoginComponent,
    RegisterComponent,
    SanPhamChiTietComponent,
    SanPhamDanhMucComponent,
    CartComponent,
    OrderComponent,
    OrderTrackingComponent,
    ContactComponent,
    Page404Component,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
