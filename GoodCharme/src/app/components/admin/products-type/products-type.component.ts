import { Component } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-products-type',
  templateUrl: './products-type.component.html',
  styleUrl: './products-type.component.css'
})
export class ProductsTypeComponent {
  productTypes: any=[];
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
    this.loadProductTypes();
  }

  loadProductTypes():void {
    this.app.productTypeList().subscribe((res: any) => {
      this.productTypes = res;
      this.calculatePagination(res.length);
    });
  }  

  onDelete(productTypeId: string) {
    const confirmDelete = confirm("Bạn có chắc chắn muốn xóa loại sản phẩm này?");
    if (confirmDelete) {
      this.app.deleteProductType(productTypeId).subscribe(res => {
        this.app.productTypeList().subscribe((res: any) => {
          this.productTypes = res;
        });
        alert("Xóa loại sản phẩm thành công.");
      });
    }
  }

  calculatePagination(totalItems: number): void {
    this.totalItems = totalItems;
    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
  }

  goToFirstPage() {
    this.currentPage = 1;
    this.loadProductTypes();
    this.preventScrollToTop();
  }

  goToLastPage() {
    this.currentPage = this.totalPages;
    this.loadProductTypes();
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

  sortProductTypes(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'desc';
    }

    this.productTypes.sort((a: any, b: any) => {
      const valueA = a[column];
      const valueB = b[column];
      if (valueA < valueB) return this.sortDirection === 'asc' ? -1 : 1;
      if (valueA > valueB) return this.sortDirection === 'asc' ? 1 : -1;
        return 0;
    });
  }
}
