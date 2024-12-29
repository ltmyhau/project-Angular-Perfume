import { Component, OnInit } from '@angular/core';
import { CartService } from '../../../services/cart.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AppService } from '../../../services/app.service';
import { UserService } from '../../../services/user.service';
import { Router } from '@angular/router';
import { MomoPaymentService } from '../../../services/momo-payment.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent implements OnInit {
  giamGia: number = 0;
  phiVanChuyen: number = 0;
  tongThanhTien: number = 0;
  customerId: string = '';
  orderId: string = '';
  submited: boolean = false;
  voucher: any;
  discountList: any[] = [];
  discountError: boolean = false;
  discountApplied: boolean = false;

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private cartService:CartService,
    private userService: UserService,
    private router: Router,
    private momoPaymentService: MomoPaymentService
  ) {}

  items = this.cartService.getItems();
  tongTien(){
    let sum: number = 0;
    this.items.forEach( items => sum += items.soLuong * items.giaBan);
    return sum;
  }
  tongSoLuong(){
    let sum: number = 0;
    this.items.forEach( items => sum += items.soLuong);
    return sum;
  }
  tongThanhToan(){
    let sum: number = 0;
    sum = this.tongTien() - this.giamGia + this.phiVanChuyen;
    return sum;
  }

  ngOnInit(): void {
    const loggedInUser = this.userService.getLoggedInUser();
    if (loggedInUser) {
      this.customerId = loggedInUser.MaKH;
      console.log(loggedInUser.MaKH);
      this.fillCustomerInfo(this.customerId);
    }
    this.loadDiscountList();
  }

  loadDiscountList() {
    this.app.discountList().subscribe((res: any) => {
      this.discountList = res;
    });
  }

  customerInfoForm : FormGroup = new FormGroup({
    HoTenKH: new FormControl('', [Validators.required]),
    DienThoai: new FormControl('', [Validators.required]),
    DiaChi: new FormControl('', [Validators.required]),
    PhuongXa: new FormControl('', [Validators.required]),
    QuanHuyen: new FormControl('', [Validators.required]),
    TinhTP: new FormControl('', [Validators.required])
  });
  get f() {return this.customerInfoForm.controls}

  fillCustomerInfo(customerId: any): void {
    this.app.customerByID(customerId).subscribe((res: any[]) => {
      console.log(res);
      res.forEach(customer => {
        this.customerInfoForm = this.fb.group({
          HoTenKH: [customer.HoTenKH ,Validators.required],
          DienThoai: [customer.DienThoai ,Validators.required],
          DiaChi: [customer.DiaChi ,Validators.required],
          PhuongXa: [customer.Phuong ,Validators.required],
          QuanHuyen: [customer.Quan ,Validators.required],
          TinhTP: [customer.ThanhPho ,Validators.required]
        });
      });
    });
  }

  discountForm = this.fb.group({
    Code: ['']
  });
  get frm() {return this.discountForm.controls}

  applyVoucher() {
    this.submited = true;
    if (this.discountForm.invalid) {
      return;
    }

    const voucherCode = this.discountForm.get('Code')?.value?.toUpperCase() ?? ''; 
    // const voucherCode = this.discountForm.get('Code')?.value;
    const voucher = this.discountList.find(v => v.Code === voucherCode);

    if (voucher) {
      if (voucher.TrangThai === 'Đang hoạt động') {
        this.discountApplied = true;
        this.discountError = false;
        this.voucher = voucher;  
        if (voucher.LoaiKM === 'Phần trăm') {
          this.giamGia = (voucher.UuDai / 100) * this.tongTien();
        } else {
          this.giamGia = voucher.UuDai;
        }
      } else {
        this.discountApplied = false;
        this.discountError = true;
        this.giamGia = 0;
        this.voucher = null;
        console.log('Mã giảm giá không hoạt động');
      }
    } else {
      this.discountApplied = false;
      this.discountError = true;
      this.giamGia = 0;
      this.voucher = null;
      console.log('Mã giảm giá không hợp lệ');
    }
  }

  placeOrder(): void {
    const loggedInUser = this.userService.getLoggedInUser();
    if (loggedInUser) {
      const customerId = loggedInUser.MaKH;

      const selectedPaymentMethod = (document.querySelector(
        'input[name="PaymentMethod"]:checked'
      ) as HTMLInputElement)?.value;

      this.orderId = 'ORD' + new Date().getTime();
      const amount = this.tongThanhToan();
      const orderInfo = 'Thanh toán đơn hàng';

      const order = { 
        MaDH: this.orderId,
        MaKH: customerId,
        MaPTTT: selectedPaymentMethod
      };

      
      console.log(order)

      this.app.addOrder(order).subscribe(res => {
        const cartItems = this.cartService.getItems();
        const orderDetails = cartItems.map((item: any) => ({
            MaDH: this.orderId,
            MaSP: item.maSP,
            SoLuong: item.soLuong
        }));

        this.app.addOrderDetails(orderDetails).subscribe(
          (res) => {
            alert("Đơn hàng đã được tạo thành công.");
            this.cartService.clearCart();

            if (selectedPaymentMethod === 'COD') {
              this.router.navigate(['/cart/order/tracking'], { queryParams: { orderId: this.orderId } });
            } else if (selectedPaymentMethod === 'MOMO') {
              this.momoPaymentService.createMoMoPayment(this.orderId, amount, orderInfo).subscribe(
                (response) => {
                  console.log('Phản hồi từ API:', response);
                  if (response?.payUrl) {
                    sessionStorage.setItem('payUrl', response.payUrl);
                    window.open(response.payUrl, '_blank');
                    this.router.navigate(['/cart/order/tracking'], { queryParams: { orderId: this.orderId } });
                  } else {
                    console.error('Không nhận được URL thanh toán:', response);
                    alert('Không nhận được URL thanh toán từ MoMo.');
                  }
                },
                (error) => {
                  console.error('Lỗi khi gọi API MoMo:', error);
                  alert('Đã xảy ra lỗi khi xử lý thanh toán. Vui lòng thử lại.');
                }
              );
            } else if (selectedPaymentMethod === 'CARD') {
              this.router.navigate(['/cart/order/tracking'], { queryParams: { orderId: this.orderId } });
            }
          },
          (error) => {
              console.error('Lỗi khi thêm chi tiết đơn hàng:', error);
          }
        );
      })
    }
  }
}
