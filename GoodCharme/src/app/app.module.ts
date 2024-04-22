import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/client/header/header.component';
import { FooterComponent } from './components/client/footer/footer.component';
import { HomeComponent } from './components/client/home/home.component';
import { AboutComponent } from './components/client/about/about.component';
import { LoginComponent } from './components/client/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './components/client/register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { SanPhamChiTietComponent } from './components/client/san-pham-chi-tiet/san-pham-chi-tiet.component';
import { SanPhamDanhMucComponent } from './components/client/san-pham-danh-muc/san-pham-danh-muc.component';
import { CartComponent } from './components/client/cart/cart.component';
import { OrderComponent } from './components/client/order/order.component';
import { OrderTrackingComponent } from './components/client/order-tracking/order-tracking.component';
import { ContactComponent } from './components/client/contact/contact.component';
import { Page404Component } from './components/client/page-404/page-404.component';
import { IndexComponent } from './components/client/index/index.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { ProductManagementComponent } from './components/admin/product-management/product-management.component';
import { OrderManagementComponent } from './components/admin/order-management/order-management.component';
import { AddProductComponent } from './components/admin/add-product/add-product.component';
import { EditProductComponent } from './components/admin/edit-product/edit-product.component';

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
    IndexComponent,
    DashboardComponent,
    ProductManagementComponent,
    OrderManagementComponent,
    AddProductComponent,
    EditProductComponent
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
