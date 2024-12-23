import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { CartService } from '../../../services/cart.service';
import { AppService } from '../../../services/app.service';
import { Router } from '@angular/router';
import { Cart } from '../../../interface/cart';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  loggedInUsername: string | undefined;
  loggedInUserAvatar: string = '/assets/images/user-avatar.png';  
  cartCount: number = 0;
  items = this.cartService.getItems();

  constructor(
    private app: AppService,
    private router: Router,
    private userService: UserService,
    private cartService: CartService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    const loggedInUser = this.userService.getLoggedInUser();
    if (loggedInUser) {
      this.loggedInUsername = loggedInUser.username;
      this.app.customerByID(loggedInUser.MaKH).subscribe((res: any[]) => {
        const customer = res[0];
        if (customer && customer.HinhAnh) {
          this.loggedInUserAvatar = customer.HinhAnh;
          this.userService.setAvatar(customer.HinhAnh);
        }
      });
    }
    this.userService.avatar$.subscribe(avatar => {
      this.loggedInUserAvatar = avatar;
    });

    this.cartService.cartCount$.subscribe((count) => {
      this.cartCount = count;
      this.items = this.cartService.getItems();
    });
  }

  searchTerm?: string;
  onSubmit() {
    if (this.searchTerm !== undefined && this.searchTerm.trim() !== '') {
      this.router.navigate(['/product-type'], { queryParams: { search: this.searchTerm } });
    }
  }

  xoaSanPhamKhoiGioHang(sanPham: Cart) {
    this.cartService.removeFromCart(sanPham);
  }

  logout() {
    this.authService.logout();
  }
}
