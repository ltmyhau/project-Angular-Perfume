import { Component } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { OrderService } from '../../../services/order.service';

@Component({
  selector: 'app-order-management',
  templateUrl: './order-management.component.html',
  styleUrl: './order-management.component.css'
})

export class OrderManagementComponent { 
  orders: any = [];
  currentPage: number = 1;
  totalItems: number = 0;
  totalPages: number = 0;
  pageSize: number = 30;

  constructor(
    private app: AppService,
    private fb: FormBuilder,
    private orderService: OrderService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders(): void {
    this.orderService.getOrders().subscribe((res: any) => {
      this.orders = res;
      this.calculatePagination(res.length);
    });
  }

  viewDetail(orderId: string): void {
    this.router.navigate(['/admin/orders/detail', orderId]);
  }

  editOrder(orderId: string): void {
    this.router.navigate(['/admin/orders/edit', orderId]);
  }

  deleteOrder(orderId: string): void {
    const confirmDelete = confirm("Bạn có chắc chắn muốn xóa đơn hàng này?");
    if (confirmDelete) {
      this.app.deleteOrder(orderId).subscribe(res => {
        this.orderService.getOrders().subscribe((res: any) => {
          this.orders = res;
        });
        alert("Xóa đơn hàng thành công.");
      });
    }
  }

  calculatePagination(totalItems: number): void {
    this.totalItems = totalItems;
    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
  }

  goToFirstPage() {
    this.currentPage = 1;
    this.loadOrders();
    this.preventScrollToTop();
  }

  goToLastPage() {
    this.currentPage = this.totalPages;
    this.loadOrders();
    this.preventScrollToTop();
  }

  preventScrollToTop() {
    window.scrollTo(0, document.body.scrollTop);
  }

  get isSinglePage(): boolean {
    return this.totalPages <= 1;
  }

  sortColumn: string = '';
  sortDirection: string = 'asc';

  sortOrders(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }

    this.orders.sort((a: any, b: any) => {
      const valueA = a[column];
      const valueB = b[column];
      if (valueA < valueB) return this.sortDirection === 'asc' ? -1 : 1;
      if (valueA > valueB) return this.sortDirection === 'asc' ? 1 : -1;
        return 0;
    });
  }
}