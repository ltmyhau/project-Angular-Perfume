import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html',
  styleUrl: './product-management.component.css'
})
export class ProductManagementComponent {

  products: any=[];
  currentPage: number = 1;
  totalItems: number = 0;
  totalPages: number = 0;
  pageSize: number = 20;

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts():void {
    this.app.productsList().subscribe((res: any) => {
      this.products = res;
      this.calculatePagination(res.length);
    });
  }  

  onDelete(productId: string) {
    const confirmDelete = confirm("Bạn có chắc chắn muốn xóa sản phẩm này?");
    if (confirmDelete) {
      console.log(productId);
      this.app.deleteProduct(productId).subscribe(res => {
        this.app.productsList().subscribe((res: any) => {
          this.products = res;
        });
        alert("Xóa sản phẩm thành công.");
      });
    }
  }

  calculatePagination(totalItems: number): void {
    this.totalItems = totalItems;
    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
  }

  goToFirstPage() {
    this.currentPage = 1;
    this.loadProducts();
    this.preventScrollToTop();
  }

  goToLastPage() {
    this.currentPage = this.totalPages;
    this.loadProducts();
    this.preventScrollToTop();
  }

  preventScrollToTop() {
    window.scrollTo(0, document.body.scrollTop);
  }

  get isSinglePage(): boolean {
    return this.totalPages <= 1;
  }

  sortColumn: string = '';
  sortDirection: string = 'desc';

  sortProducts(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'desc';
    }

    this.products.sort((a: any, b: any) => {
      const valueA = a[column];
      const valueB = b[column];
      if (valueA < valueB) return this.sortDirection === 'asc' ? -1 : 1;
      if (valueA > valueB) return this.sortDirection === 'asc' ? 1 : -1;
        return 0;
    });
  }
}
