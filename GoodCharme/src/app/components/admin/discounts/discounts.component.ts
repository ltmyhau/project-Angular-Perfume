import { Component } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-discounts',
  templateUrl: './discounts.component.html',
  styleUrl: './discounts.component.css'
})
export class DiscountsComponent {
  discounts: any=[];
  currentPage: number = 1;
  totalItems: number = 0;
  totalPages: number = 0;
  pageSize: number = 20;

  constructor( 
    private app: AppService
  ) { }

  ngOnInit(): void {
    this.loadDiscounts();
  }

  loadDiscounts():void {
    this.app.discountList().subscribe((res: any) => {
      this.discounts = res;
      this.calculatePagination(res.length);
    });
  }  

  onDelete(discountId: string) {
    const confirmDelete = confirm("Bạn có chắc chắn muốn xóa khuyến mãi này?");
    if (confirmDelete) {
      this.app.deleteDiscount(discountId).subscribe(res => {
        this.app.discountList().subscribe((res: any) => {
          this.discounts = res;
        });
        alert("Xóa khuyến mãi thành công.");
      });
    }
  }

  calculatePagination(totalItems: number): void {
    this.totalItems = totalItems;
    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
  }

  goToFirstPage() {
    this.currentPage = 1;
    this.loadDiscounts();
    this.preventScrollToTop();
  }

  goToLastPage() {
    this.currentPage = this.totalPages;
    this.loadDiscounts();
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

  sortDiscounts(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'desc';
    }

    this.discounts.sort((a: any, b: any) => {
      const valueA = a[column];
      const valueB = b[column];
      if (valueA < valueB) return this.sortDirection === 'asc' ? -1 : 1;
      if (valueA > valueB) return this.sortDirection === 'asc' ? 1 : -1;
        return 0;
    });
  }
}
