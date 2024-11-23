import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { CartService } from '../../../services/cart.service';
import { AppService } from '../../../services/app.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  loggedInUsername: string | undefined;
  cartCount: number = 0;

  constructor(
    private app: AppService,
    private router: Router,
    private userService: UserService,
    private cartService: CartService
  ) { }

  ngOnInit(): void {
    const loggedInUser = this.userService.getLoggedInUser();
    console.log(loggedInUser);
    if (loggedInUser) {
      this.loggedInUsername = loggedInUser.username;
    }
    this.cartService.cartCount$.subscribe((count) => {
      this.cartCount = count;
    });
  }

  searchTerm?: string;
  onSubmit() {
    if (this.searchTerm !== undefined && this.searchTerm.trim() !== '') {
      this.router.navigate(['/product-type'], { queryParams: { search: this.searchTerm } });
    }
  }
}
