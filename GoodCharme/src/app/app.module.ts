import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxPaginationModule } from 'ngx-pagination';

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
import { Page404Component } from './components/page-404/page-404.component';
import { IndexComponent } from './components/client/index/index.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { ProductManagementComponent } from './components/admin/product-management/product-management.component';
import { OrderManagementComponent } from './components/admin/order-management/order-management.component';
import { AddProductComponent } from './components/admin/product-management/add-product/add-product.component';
import { EditProductComponent } from './components/admin/product-management/edit-product/edit-product.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { AccountComponent } from './components/client/account/account.component';
import { ProfileComponent } from './components/client/account/profile/profile.component';
import { AddressComponent } from './components/client/account/address/address.component';
import { PasswordComponent } from './components/client/account/password/password.component';
import { PurchaseComponent } from './components/client/account/purchase/purchase.component';
import { PaymentCompleteComponent } from './components/client/payment-complete/payment-complete.component';
import { OverviewComponent } from './components/admin/overview/overview.component';
import { DetailOrderComponent } from './components/admin/order-management/detail-order/detail-order.component';
import { EditOrderComponent } from './components/admin/order-management/edit-order/edit-order.component';
import { DetailProductComponent } from './components/admin/product-management/detail-product/detail-product.component';
import { CustomerManagementComponent } from './components/admin/customer-management/customer-management.component';
import { DetailCustomerComponent } from './components/admin/customer-management/detail-customer/detail-customer.component';
import { EditCustomerComponent } from './components/admin/customer-management/edit-customer/edit-customer.component';
import { EmployeeManagementComponent } from './components/admin/employee-management/employee-management.component';
import { DetailEmployeeComponent } from './components/admin/employee-management/detail-employee/detail-employee.component';
import { EditEmployeeComponent } from './components/admin/employee-management/edit-employee/edit-employee.component';
import { AddEmployeeComponent } from './components/admin/employee-management/add-employee/add-employee.component';
import { AddCustomerComponent } from './components/admin/customer-management/add-customer/add-customer.component';
import { ProductsTypeComponent } from './components/admin/products-type/products-type.component';
import { DiscountsComponent } from './components/admin/discounts/discounts.component';
import { EditDiscountComponent } from './components/admin/discounts/edit-discount/edit-discount.component';
import { EditProductTypeComponent } from './components/admin/products-type/edit-product-type/edit-product-type.component';
import { AddProductTypeComponent } from './components/admin/products-type/add-product-type/add-product-type.component';
import { AddDiscountComponent } from './components/admin/discounts/add-discount/add-discount.component';
import { DetailDiscountComponent } from './components/admin/discounts/detail-discount/detail-discount.component';
import { DetailProductTypeComponent } from './components/admin/products-type/detail-product-type/detail-product-type.component';

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
    EditProductComponent,
    AccessDeniedComponent,
    AccountComponent,
    ProfileComponent,
    AddressComponent,
    PasswordComponent,
    PurchaseComponent,
    PaymentCompleteComponent,
    OverviewComponent,
    DetailOrderComponent,
    EditOrderComponent,
    DetailProductComponent,
    CustomerManagementComponent,
    DetailCustomerComponent,
    EditCustomerComponent,
    EmployeeManagementComponent,
    DetailEmployeeComponent,
    EditEmployeeComponent,
    AddEmployeeComponent,
    AddCustomerComponent,
    ProductsTypeComponent,
    EditProductTypeComponent,
    DiscountsComponent,
    EditDiscountComponent,
    AddProductTypeComponent,
    AddDiscountComponent,
    DetailDiscountComponent,
    DetailProductTypeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgxPaginationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
