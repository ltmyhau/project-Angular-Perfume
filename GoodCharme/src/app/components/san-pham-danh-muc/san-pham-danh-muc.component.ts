import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppService } from '../../services/app.service';
import { CartService } from '../../services/cart.service';
import { Product } from '../../interface/product';

@Component({
  selector: 'app-san-pham-danh-muc',
  templateUrl: './san-pham-danh-muc.component.html',
  styleUrl: './san-pham-danh-muc.component.css'
})
export class SanPhamDanhMucComponent implements OnInit {
  tuGia?: number;
  denGia?: number;
  products: any=[];

  constructor(
    private route: ActivatedRoute,
    private app: AppService,
    private cartService: CartService
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
  
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      switch (idParam) {
        case 'nuoc-hoa-nam':
          this.getProducts(1);
          break;
        case 'nuoc-hoa-nu':
          this.getProducts(2);
          break;
        case 'nuoc-hoa-tre-em':
          this.getProducts(3);
          break;
        case 'nuoc-hoa-xe-hoi':
          this.getProducts(4);
          break;
        case 'my-pham':
          this.getProducts(5);
          break;
        case 'cham-soc-toan-than':
          this.getProducts(6);
          break;
        case 'tinh-dau-thien-nhien':
          this.getProducts(7);
          break;
        case 'nuoc-hoa':
          this.app.NuocHoaList().subscribe((res: any) => {
            this.products = res;
          });
          break;
        case 'san-pham-khac':
          this.app.SanPhamKhacList().subscribe((res: any) => {
            this.products = res;
          });
          break;
        default:
          this.app.productsList().subscribe((res: any) => {
            this.products = res;
          });
          break;
      }
    });
  }

  getProducts(id: number = 1): void {
    this.app.productsByMaLoaiSP(id).subscribe((res: any) => {
      this.products = res;
    });
  }

  getProductsByPrice() {
    if (this.tuGia !== undefined && this.denGia !== undefined) {
      this.app.productsByPrice(this.tuGia, this.denGia).subscribe((res: any) => {
        this.products = res;
      });
    }
  }

}
