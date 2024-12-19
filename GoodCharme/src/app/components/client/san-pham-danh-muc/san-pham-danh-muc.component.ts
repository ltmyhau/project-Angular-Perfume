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
  tuGia: number | null = null;
  denGia: number | null = null;
  products: Product[] = [];
  currentPage: number = 1;
  pageSize: number = 20;
  totalItems: number = 0;
  totalPages: number = 0;
  currentSort: string = '';

  isProductAdded: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private app: AppService,
    private router: Router,
    private cartService: CartService,
    private userService: UserService
  ) { }

  addToCart(product: Product, quantity: number = 1) {
    this.cartService.addToCart(product, quantity);
      console.log(this.cartService.getItems());
      this.isProductAdded = true;
      setTimeout(() => {
          this.isProductAdded = false;
      }, 3000);
  }

  ngOnInit(): void {
    combineLatest([this.route.paramMap, this.route.queryParams]).subscribe(([paramMap, queryParams]) => {
      const searchTerm = queryParams['search'];
      const idParam = paramMap.get('id');
      this.currentPage = 1;

      if (searchTerm) {
        this.app.searchProduct(searchTerm).subscribe(res => {
          this.products = res;
          this.calculatePagination(res.length);
        });
      } else {
        this.loadProductsByCategory(idParam);
      }
    });
  }

  loadProductsByCategory(idParam: string | null): void {
    const categoryMap: { [key: string]: string } = {
      'nuoc-hoa-nam': 'LSP000001',
      'nuoc-hoa-nu': 'LSP000002',
      'nuoc-hoa-tre-em': 'LSP000003',
      'nuoc-hoa-xe-hoi': 'LSP000004',
      'my-pham': 'LSP000005',
      'cham-soc-toan-than': 'LSP000006',
      'tinh-dau-thien-nhien': 'LSP000007',
    };

    if (categoryMap[idParam!]) {
      this.getProducts(categoryMap[idParam!]);
    } else if (idParam === 'nuoc-hoa') {
      this.app.NuocHoaList().subscribe(res => {
        this.products = res;
        this.calculatePagination(res.length);
      });
    } else if (idParam === 'san-pham-khac') {
      this.app.SanPhamKhacList().subscribe(res => {
        this.products = res;
        this.calculatePagination(res.length);
      });
    } else {
      this.app.productsList().subscribe(res => {
        this.products = res;
        this.calculatePagination(res.length);
      });
    }
  }

  getProducts(id: string = 'LSP000001'): void {
    this.app.productsByMaLoaiSP(id).subscribe((res: any) => {
      this.products = res;
      this.calculatePagination(res.length);
    });
  }

  getProductsByPrice() {
    if (this.tuGia !== undefined && this.denGia !== undefined && this.tuGia !== null && this.denGia !== null) {
      this.app.productsByPrice(this.tuGia, this.denGia).subscribe((res: any) => {
        this.products = res;
        this.calculatePagination(res.length);
      });
    }
  }

  calculatePagination(totalItems: number): void {
    this.totalItems = totalItems;
    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
  }

  goToFirstPage() {
    this.currentPage = 1;
    if (this.tuGia !== undefined && this.denGia !== undefined && this.tuGia !== null && this.denGia !== null) {
      this.app.productsByPrice(this.tuGia, this.denGia).subscribe((res: any) => {
        this.products = res;
        this.calculatePagination(res.length);
      });
    } else {
      this.loadProductsByCategory(this.route.snapshot.paramMap.get('id'));
    }
    this.preventScrollToTop();
  }

  goToLastPage() {
    this.currentPage = this.totalPages;
    if (this.tuGia !== undefined && this.denGia !== undefined && this.tuGia !== null && this.denGia !== null) {
      this.app.productsByPrice(this.tuGia, this.denGia).subscribe((res: any) => {
        this.products = res;
        this.calculatePagination(res.length);
      });
    } else {
      this.loadProductsByCategory(this.route.snapshot.paramMap.get('id'));
    }
    this.preventScrollToTop();
  }

  get isSinglePage(): boolean {
    return this.totalPages <= 1;
  }

  preventScrollToTop() {
    window.scrollTo(0, document.body.scrollTop);
  }

  activeSort: string = 'popular';
  selectedPriceSort: string = ''; 

  sortBy(criteria: string): void {
    this.activeSort = criteria;
    const sortFunctions: { [key: string]: (a: Product, b: Product) => number } = {
      popular: (a, b) => {
        const numA = this.extractNumberFromMaSP(a.MaSP);
        const numB = this.extractNumberFromMaSP(b.MaSP);
        return numA - numB;
      },
      newest: (a, b) => new Date(b.NgayThem).getTime() - new Date(a.NgayThem).getTime(),
      bestseller: (a, b) => b.TongSoLuongBan - a.TongSoLuongBan,
      priceAsc: (a, b) => a.GiaBan - b.GiaBan,
      priceDesc: (a, b) => b.GiaBan - a.GiaBan,
    };

    const sortFunction = sortFunctions[criteria];
    if (sortFunction) {
      this.products.sort(sortFunction);
    }
  }

  extractNumberFromMaSP(maSP: string): number {
    const match = maSP.match(/\d+$/);
    return match ? Number(match[0]) : 0;
  }

  clearCategoryInput(): void {
    this.tuGia = null;
    this.denGia = null;
  }

  selectedDisplay: string = 'grid';

  updatePageSize() {
    this.pageSize = this.selectedDisplay === 'list' ? 10 : 20;
    this.currentPage = 1;
  }

  setDisplay(displayType: string): void {
    this.selectedDisplay = displayType;
    this.updatePageSize();
  }

  productRoutes: { [key: string]: string } = {
    'LSP000001': 'nuoc-hoa-nam',
    'LSP000002': 'nuoc-hoa-nu',
    'LSP000003': 'nuoc-hoa-tre-em',
    'LSP000004': 'nuoc-hoa-xe-hoi',
    'LSP000005': 'my-pham',
    'LSP000006': 'cham-soc-toan-than',
    'LSP000007': 'tinh-dau-thien-nhien',
  };

  getRouterLink(maSP: string): string {
    return this.productRoutes[maSP] ? `/product-type/${this.productRoutes[maSP]}` : '/product-type/all';
  }
}
