import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '../../../../services/app.service';
import { Location } from '@angular/common';
import { OrderService } from '../../../../services/order.service';

@Component({
  selector: 'app-detail-order',
  templateUrl: './detail-order.component.html',
  styleUrl: './detail-order.component.css'
})
export class DetailOrderComponent {
  order: any;
  customer: any;
  orderDetails: any[] = [];

  constructor(
    private app: AppService,
    private route: ActivatedRoute,
    private orderService: OrderService,
    private location: Location
  ) {}   

  ngOnInit(): void {
    const orderId = this.route.snapshot.paramMap.get('id');
    if (orderId) {
      this.loadOrder(orderId);
      this.loadOrderDetail(orderId);
    }
  }

  goBack(): void {
    this.location.back();
  }

  loadOrder(orderId: string): void {
    this.orderService.getOrderById(orderId).subscribe(
      (res: any) => {
        this.order = res[0];
        if (this.order && this.order.maKH) {
          this.loadCustomer(this.order.maKH);
        }
      },
      (error) => {
        console.error('Lỗi khi lấy đơn hàng:', error);
      }
    );
  }

  loadOrderDetail(orderId: string): void {
    this.orderService.getOrderDetailsByOrderId(orderId).subscribe(
      (res: any[]) => {
        this.orderDetails = res;
      },
      (error) => {
        console.error('Lỗi khi lấy chi tiết đơn hàng:', error);
      }
    );
  }

  loadCustomer(id: string): void {
    this.app.customerByID(id).subscribe(
      (res: any) => {
        this.customer = res;
      },
      (error: any) => {
        console.error('Lỗi khi lấy khách hàng:', error);
      }
    );
  }

  tongTien(){
    let sum: number = 0;
    this.orderDetails.forEach( items => sum += items.SoLuong * items.GiaBan);
    return sum;
  }
}
