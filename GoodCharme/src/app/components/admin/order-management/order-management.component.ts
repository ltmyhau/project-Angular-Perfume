import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { formatDate } from '@angular/common';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-order-management',
  templateUrl: './order-management.component.html',
  styleUrl: './order-management.component.css'
})

export class OrderManagementComponent implements OnInit {
  @ViewChild('orderForm') orderForm!: ElementRef;

  showOrderForm(orderID: number) {
    this.orderForm.nativeElement.style.display = 'block';

    this.app.orderByID(orderID).subscribe((res: any[]) => {
      console.log(res);
      res.forEach(order => {
        const formattedNgayDat = new Date(order.NgayDat).toISOString().slice(0, 10);
        const formattedNgayGiao = new Date(order.NgayGiao).toISOString().slice(0, 10);
        this.orderInfo = this.fb.group({
          MaDH: [order.MaDH],
          HoTenKH: [order.HoTenKH],
          NgayDat: [formattedNgayDat],
          NgayGiao: [formattedNgayGiao, Validators.required],
          MaTT: [order.MaTT, Validators.required]
        });
      });
    });
  }
  

  hideOrderForm() {
    this.orderForm.nativeElement.style.display = 'none';
  }

  datePipe = new DatePipe('en-US');
  orders: any=[];
  orderStatusList: any=[];

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.app.orderList().subscribe((res: any) => {
      this.orders = res;
    });

    this.app.orderStatusList().subscribe(res => {
      this.orderStatusList = res;
    });
  }

  submited: boolean = false;
  orderInfo = this.fb.group({
    MaDH: [''],
    HoTenKH: [''],
    NgayDat: [''],
    NgayGiao: ['', Validators.required],
    MaTT: ['', Validators.required]
  });

  get f() {return this.orderInfo.controls}
  onUpdate(): any {
    this.submited = true;
    if(this.orderInfo.invalid) {return false;}

    console.log(this.orderInfo.value);
    this.app.editOrder(this.orderInfo.value).subscribe(res => {
      alert("Cập nhập đơn hàng thành công.");
      this.orderForm.nativeElement.style.display = 'none';
      this.app.orderList().subscribe((res: any) => {
        this.orders = res;
      });
    })
  }
}
