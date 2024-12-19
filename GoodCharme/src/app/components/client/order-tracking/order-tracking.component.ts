import { Component } from '@angular/core';
import { CartService } from '../../../services/cart.service';
import { ActivatedRoute } from '@angular/router';
import { AppService } from '../../../services/app.service';

@Component({
  selector: 'app-order-tracking',
  templateUrl: './order-tracking.component.html',
  styleUrl: './order-tracking.component.css'
})
export class OrderTrackingComponent {
  giamGia: number = 0;
  phiVanChuyen: number = 0;
  tongThanhTien: number = 0;
  orderId: string = '';
  order: any;
  orderDetails: any[] = [];
  paymentStatus: string = '';
  interval: any;
  payUrl: string = ''; 

  constructor( 
    private route: ActivatedRoute,
    private app: AppService
  ) {}
  
  tongTien(){
    let sum: number = 0;
    this.orderDetails.forEach( items => sum += items.SoLuong * items.GiaBan);
    return sum;
  }
  tongSoLuong(){
    let sum: number = 0;
    this.orderDetails.forEach( items => sum += items.SoLuong);
    return sum;
  }
  tongThanhToan(){
    let sum: number = 0;
    sum = this.tongTien() - this.giamGia + this.phiVanChuyen;
    return sum;
  }

  ngOnInit(): void {
    const payUrl = sessionStorage.getItem('payUrl');

    if (payUrl) {
      this.payUrl = payUrl;
    }

    this.route.queryParams.subscribe(params => {
      this.orderId = params['orderId'];
      if (this.orderId) {
        this.fetchOrderDetails();
        this.fetchOrderInfo();
        this.startPaymentCheck();
        this.fetchPaymentStatus();
      }
    });
  }

  fetchOrderInfo(): void {
    this.app.orderByID(this.orderId).subscribe(
      (res: any) => {
        this.order = res[0];
      },
      (error) => {
        console.error('Lỗi khi lấy thông tin đơn hàng:', error);
      }
    );
  }

  fetchOrderDetails(): void {
    this.app.getOrderDetailsByOrderId(this.orderId).subscribe(
      (res: any[]) => {
        this.orderDetails = res;
        console.log('Chi tiết đơn hàng:', this.orderDetails);
      },
      (error) => {
        console.error('Lỗi khi lấy chi tiết đơn hàng:', error);
      }
    );
  }

  fetchPaymentStatus(): void {
    this.app.getPaymentStatus(this.orderId).subscribe(
      (res: any) => {
        if (res.resultCode === 1000) {
          this.paymentStatus = 'Đang chờ thanh toán';
        } else if (res.resultCode === 0) {
          this.paymentStatus = 'Thanh toán thành công';
          this.stopPaymentCheck();
        } else {
          this.paymentStatus = 'Thanh toán thất bại';
          this.stopPaymentCheck();
        }
        console.log('Trạng thái thanh toán:', this.paymentStatus);
      },
      (error) => {
        console.error('Lỗi khi lấy trạng thái thanh toán:', error);
      }
    );
  }

  startPaymentCheck(): void {
    this.interval = setInterval(() => {
      this.fetchPaymentStatus();
    }, 5000);
  }

  stopPaymentCheck(): void {
    if (this.interval) {
      clearInterval(this.interval);
      this.interval = null;
    }
  }

  ngOnDestroy(): void {
    this.stopPaymentCheck();
  }
}
