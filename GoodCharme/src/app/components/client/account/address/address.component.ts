import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../../../services/user.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrl: './address.component.css'
})
export class AddressComponent {
  customerId: string = '';

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    const loggedInUser = this.userService.getLoggedInUser();
    if (loggedInUser) {
      this.customerId = loggedInUser.MaKH;
      this.fillCustomerInfo(this.customerId);
    }
  }

  customerAddressForm : FormGroup = new FormGroup({
    MaKH: new FormControl('', [Validators.required]),
    HoTenKH: new FormControl('', [Validators.required]),
    DienThoai: new FormControl('', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]),
    DiaChi: new FormControl('', [Validators.required]),
    Phuong: new FormControl('', [Validators.required]),
    Quan: new FormControl('', [Validators.required]),
    ThanhPho: new FormControl('', [Validators.required])
  });
  get f() {return this.customerAddressForm.controls}

  fillCustomerInfo(customerId: any): void {
    const loggedInUser = this.userService.getLoggedInUser();
    this.app.customerByID(customerId).subscribe((res: any[]) => {
      res.forEach(customer => {
        this.customerAddressForm.patchValue({
          MaKH: customerId,
          HoTenKH: customer.HoTenKH,
          DienThoai: customer.DienThoai,
          DiaChi: customer.DiaChi,
          Phuong: customer.Phuong,
          Quan: customer.Quan,
          ThanhPho: customer.ThanhPho
        });
      });
    });
  }

  isSaveCustomer: boolean = false;

  saveCustomerAddress(): void {
    this.customerAddressForm.markAllAsTouched();

    if (this.customerAddressForm.invalid) {
      console.log('Form không hợp lệ');
      return;
    }

    const customerData = this.customerAddressForm.value;
    console.log(customerData)
    this.app.editCustomerAddress(this.customerId, customerData).subscribe(response => {
      console.log('Thông tin giao hàng đã được lưu thành công', response);
      this.isSaveCustomer = true;
      setTimeout(() => {
          this.isSaveCustomer = false;
      }, 2000);
    }, error => {
      console.error('Lỗi khi lưu thông tin giao hàng', error);
    });
  }
}
