import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { SanPhamChiTietComponent } from './components/san-pham-chi-tiet/san-pham-chi-tiet.component';
import { SanPhamDanhMucComponent } from './components/san-pham-danh-muc/san-pham-danh-muc.component';
import { CartComponent } from './components/cart/cart.component';
import { OrderComponent } from './components/order/order.component';
import { OrderTrackingComponent } from './components/order-tracking/order-tracking.component';
import { ContactComponent } from './components/contact/contact.component';
import { Page404Component } from './components/page-404/page-404.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'about', component: AboutComponent},
  {path: 'login', component: LoginComponent},
  {path: '404', component: Page404Component},
  {path: 'register', component: RegisterComponent},
  {path: 'product/:id', component: SanPhamChiTietComponent},
  {path: 'product-type/:id', component: SanPhamDanhMucComponent},
  {path: 'cart', component: CartComponent},
  {path: 'cart/order', component: OrderComponent},
  {path: 'cart/order/tracking', component: OrderTrackingComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
