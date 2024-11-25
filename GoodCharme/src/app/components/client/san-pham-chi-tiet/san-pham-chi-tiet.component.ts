import { Component, OnInit } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CartService } from '../../../services/cart.service';
import { Product } from '../../../interface/product';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-san-pham-chi-tiet',
  templateUrl: './san-pham-chi-tiet.component.html',
  styleUrl: './san-pham-chi-tiet.component.css'
})
export class SanPhamChiTietComponent implements OnInit {
  quantity: number = 1;
  product: any;
  productId: number = 1;
  relatedProducts: any=[];

  handlePlus() {
    this.quantity++;
  }

  handleMinus() {
    if (this.quantity > 1) {
      this.quantity--;
    } else {
      alert("Số lượng sản phẩm tối thiểu.");
    }
  }

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private app: AppService,
    private cartService: CartService,
    private userService: UserService
  ) { }

  isProductAdded: boolean = false;

  addToCart(product: Product, quantity: number = 1) {
    this.cartService.addToCart(product, quantity);
      console.log(this.cartService.getItems());
      this.isProductAdded = true;
      setTimeout(() => {
          this.isProductAdded = false;
      }, 3000);
  }

  buyNow(product: Product, quantity: number = 1) {
    this.cartService.clearCart();
    this.cartService.addToCart(product, quantity);
    console.log(this.cartService.getItems());
    this.router.navigateByUrl('/cart/order');
  }

  ngOnInit(): void {
    // this.productId = Number(this.route.snapshot.params['id']);
    // this.getProducts(this.productId);
    // this.getRelatedProducts();
    this.route.paramMap.subscribe((params) => {
      const id = Number(params.get('id'));
      if (id) {
        this.productId = id;
        this.getProducts(this.productId);
        this.getRelatedProducts();
      }
    });
  }

  getProducts(idSP: number): void {
    this.app.productDetail(idSP).subscribe((res: any) => {
      this.product = res;
    });
  }

  getRelatedProducts(limit: number = 10){
    this.app.relatedProducts(limit).subscribe((res: any) => {
      this.relatedProducts = res;
    });
  }
}