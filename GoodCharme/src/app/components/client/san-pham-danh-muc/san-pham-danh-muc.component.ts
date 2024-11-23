import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { AppService } from '../../../services/app.service';
import { CartService } from '../../../services/cart.service';
import { Product } from '../../../interface/product';
import { UserService } from '../../../services/user.service';
import { combineLatest } from 'rxjs';

@Component({
  selector: 'app-san-pham-danh-muc',
  templateUrl: './san-pham-danh-muc.component.html',
  styleUrl: './san-pham-danh-muc.component.css'
})
export class SanPhamDanhMucComponent implements OnInit {
  tuGia?: number;
  denGia?: number;
  products: any=[];
  p: number = 1;
  pageSize: number = 20;
  totalItems: number = 0;
  totalPages: number = 0;

  constructor(
    private route: ActivatedRoute,
    private app: AppService,
    private router: Router,
    private cartService: CartService,
    private userService: UserService
  ) { }

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
  combineLatest([
    this.route.paramMap,
    this.route.queryParams
  ]).subscribe(([paramMap, queryParams]) => {
    const searchTerm = queryParams['search'];
    const idParam = paramMap.get('id');

    this.p = 1;

    if (searchTerm) {
      this.app.searchProduct(searchTerm).subscribe((res: any) => {
        this.products = res;
        this.calculatePagination(res.length);
      });
    } else {
      this.loadProductsByCategory(idParam);
    }
  });
}
 

  loadProductsByCategory(idParam: string | null): void {
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
          this.calculatePagination(res.length);
        });
        break;
      case 'san-pham-khac':
        this.app.SanPhamKhacList().subscribe((res: any) => {
          this.products = res;
          this.calculatePagination(res.length);
        });
        break;
      default:
        this.app.productsList().subscribe((res: any) => {
          this.products = res;
          this.calculatePagination(res.length);
        });
        break;
    }
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

  calculatePagination(totalItems: number): void {
    this.totalItems = totalItems;
    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
  }

  goToFirstPage() {
    this.p = 1;
    this.loadProductsByCategory(this.route.snapshot.paramMap.get('id'));
  }

  goToLastPage() {
    this.p = this.totalPages;
    this.loadProductsByCategory(this.route.snapshot.paramMap.get('id'));
  }

  get isSinglePage(): boolean {
    return this.totalPages <= 1;
  }

}
