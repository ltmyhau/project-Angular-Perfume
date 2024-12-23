import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { OrderService } from '../../../../services/order.service';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrl: './edit-order.component.css'
})
export class EditOrderComponent {
  order: any;
  customer: any;
  orderDetails: any[] = [];
  orderStatusList: any = [];
  paymentMethods: any = [];
  selectedOrderStatus: string = '';
  selectedPaymentMethod: string = '';

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
    this.app.orderStatusList().subscribe(res => {
      this.orderStatusList = res;
    });
    this.app.getPaymentMethods().subscribe(res => {
      this.paymentMethods = res;
    });
  }

  goBack(): void {
    this.location.back();
  }

  loadOrder(orderId: string): void {
    this.orderService.getOrderById(orderId).subscribe(
      (res: any) => {
        this.order = res[0];
        this.selectedOrderStatus = this.order.MaTT;
        this.selectedPaymentMethod = this.order.MaPTTT;
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

  saveOrder() {
    const data = {
      maDH: this.order.MaDH,
      maTT: this.selectedOrderStatus,
      maPTTT: this.selectedPaymentMethod
    };
    this.app.editOrder(data).subscribe(res => {
      alert("Cập nhập đơn hàng thành công.");
      this.goBack();
    })
  }
}