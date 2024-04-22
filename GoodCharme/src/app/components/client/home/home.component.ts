import { Component, OnInit } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { CartService } from '../../../services/cart.service';
import { Product } from '../../../interface/product';
import { UserService } from '../../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  productsBestSeller: any=[];
  productsNew: any=[];
  imgs: any = [];
  current: number = 0;
  intervalId: any;

  constructor(
    private app:AppService,
    private cartService: CartService,
    private router: Router,
    private userService: UserService
  ) {}
  
  isProductAdded: boolean = false;

  addToCart(product: Product, quantity: number = 1) {
    const loggedInUser = this.userService.getLoggedInUser();
    if (loggedInUser) {
      this.cartService.addToCart(product, quantity);
      console.log(this.cartService.getItems());
      this.isProductAdded = true;
      setTimeout(() => {
          this.isProductAdded = false;
      }, 3000);
    }
    else {
      this.router.navigate(['/login']);
    }
  }

  ngOnInit(): void {
    this.getProductsBestSeller();
    this.getProductsNew();

    this.imgs = document.querySelectorAll('.banner_item');
    this.intervalId = setInterval(this.changeImage.bind(this), 4000);
  }

  getProductsBestSeller(limit: number = 10){
    this.app.productsBestSeller(limit).subscribe((res: any) => {
      this.productsBestSeller = res;
    });
  }

  getProductsNew(limit: number = 10){
    this.app.productsNew(limit).subscribe((res: any) => {
      this.productsNew = res;
    });
  }

  changeImage() {
    const listImage = document.querySelector('.banner_list') as HTMLElement;
    if (listImage) {
        if (this.current == this.imgs.length - 1) {
            this.current = 0;
        } else {
            this.current++;
        }
        let width = this.imgs[0].clientWidth;
        listImage.style.transform = `translateX(${-1 * width * this.current}px)`;
    }
  }

  moveLeft() {
    clearInterval(this.intervalId);
    if (this.current == 0) {
      this.current = this.imgs.length - 1;
    } else {
      this.current--;
    }
    let width = this.imgs[0].clientWidth;
    const listImage = document.querySelector('.banner_list') as HTMLElement;
    if (listImage) {
      listImage.style.transform = `translateX(${-1 * width * this.current}px)`;
    }
    this.intervalId = setInterval(this.changeImage.bind(this), 4000);
  }

  moveRight() {
    clearInterval(this.intervalId);
    this.changeImage();
    this.intervalId = setInterval(this.changeImage.bind(this), 4000);
  }
}