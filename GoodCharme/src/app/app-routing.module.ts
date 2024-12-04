import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/client/home/home.component';
import { AboutComponent } from './components/client/about/about.component';
import { LoginComponent } from './components/client/login/login.component';
import { RegisterComponent } from './components/client/register/register.component';
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
import { RoleGuardService } from './services/role-guard.service';
import { OrderManagementComponent } from './components/admin/order-management/order-management.component';
import { AddProductComponent } from './components/admin/add-product/add-product.component';
import { EditProductComponent } from './components/admin/edit-product/edit-product.component';
import { AdminGuard } from './guard/admin.guard';
import { BehaviorSubject } from 'rxjs';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { AccountComponent } from './components/client/account/account.component';
import { ProfileComponent } from './components/client/account/profile/profile.component';
import { AddressComponent } from './components/client/account/address/address.component';
import { PasswordComponent } from './components/client/account/password/password.component';
import { PurchaseComponent } from './components/client/account/purchase/purchase.component';

const routes: Routes = [
  // {
  //   path: 'admin',component:DashboardComponent,canActivate: [RoleGuardService],data: {expectedRole: "ROLE_ADMIN"},
  //   children:[
  //     {path:"product",component: ProductManagementComponent},
  //   ]
  // },

  {
    path:'admin',component: DashboardComponent, canActivate: [AdminGuard],
    children:[
    {path: '', component: DashboardComponent},
    {path: 'product', component: ProductManagementComponent},
    {path: 'product/add', component: AddProductComponent},
    {path: 'product/edit/:id', component: EditProductComponent},
    {path: 'order', component: OrderManagementComponent}
    ]
  },
  {
    path:'',component: IndexComponent,
    children:[
    {path: '', component: HomeComponent},
    {path: 'contact', component: ContactComponent},
    {path: 'about', component: AboutComponent},
    {path: 'product/:id', component: SanPhamChiTietComponent},
    {path: 'product-type', component: SanPhamDanhMucComponent},
    {path: 'product-type/:id', component: SanPhamDanhMucComponent},
    {path: 'cart', component: CartComponent},
    {path: 'cart/order', component: OrderComponent},
    {path: 'cart/order/tracking', component: OrderTrackingComponent},
    {path: 'account', component: AccountComponent,
      children: [
        { path: 'profile', component: ProfileComponent },
        { path: 'address', component: AddressComponent },
        { path: 'password', component: PasswordComponent },
        { path: 'purchase', component: PurchaseComponent }
      ]
    },
    ]
  },
  {path:'login',component:LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'access-denied', component: AccessDeniedComponent},
  {path: '**', component: Page404Component}
];

@NgModule({
  // imports: [RouterModule.forRoot(routes)],
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'enabled',
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }