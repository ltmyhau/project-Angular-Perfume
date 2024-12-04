import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../../../services/user.service';
import { AppService } from '../../../../services/app.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  customerId: string = '';
  avatarUrl: string = '/assets/images/user-avatar.png';

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

  customerInfoForm : FormGroup = new FormGroup({
    Username: new FormControl('', [Validators.required]),
    HoTenKH: new FormControl('', [Validators.required]),
    DienThoai: new FormControl('', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]),
    Email: new FormControl('', [Validators.required, Validators.email]),
    GioiTinh: new FormControl('Nam'),
    NgaySinh: new FormControl('', [Validators.required]),
    HinhAnh: new FormControl('')
  });
  get f() {return this.customerInfoForm.controls}

  fillCustomerInfo(customerId: any): void {
    const loggedInUser = this.userService.getLoggedInUser();
    this.app.customerByID(customerId).subscribe((res: any[]) => {
      res.forEach(customer => {
        const formattedNgaySinh = new Date(customer.NgaySinh + 'Z').toISOString().slice(0, 10);
        this.customerInfoForm.patchValue({
          Username: loggedInUser?.username || '',
          HoTenKH: customer.HoTenKH,
          DienThoai: customer.DienThoai,
          Email: customer.Email,
          GioiTinh: customer.GioiTinh,
          NgaySinh: formattedNgaySinh,
          HinhAnh: customer.HinhAnh
        });
        if (customer.HinhAnh) {
          this.avatarUrl = customer.HinhAnh;
        } else {
          this.avatarUrl = '/assets/images/user-avatar.png';
        }
      });
    });
  }
  
  chooseImage(): void {
    const input = document.createElement('input');
    input.type = 'file';
    input.accept = 'image/*';
    input.onchange = (event: any) => {
      const file = event.target.files[0];
      if (file) {
        this.previewImage(file);
        this.updateImageInForm(file);
      }
    };
    input.click();
  }

  previewImage(file: File): void {
    const reader = new FileReader();    
    reader.onload = (event: any) => {
      this.avatarUrl = reader.result as string;
    };
    reader.readAsDataURL(file);    
  }

  updateImageInForm(file: File): void {
    const reader = new FileReader();
    reader.onload = () => {
      const imageUrl = reader.result as string;
      this.customerInfoForm.patchValue({
        HinhAnh: imageUrl
      });
    };
    reader.readAsDataURL(file);
  }

  isSaveCustomer: boolean = false;

  saveCustomerInfo(): void {
    this.customerInfoForm.markAllAsTouched();

    if (this.customerInfoForm.invalid) {
      console.log('Form không hợp lệ');
      return;
    }

    const customerData = this.customerInfoForm.value;
    delete customerData.Username;
    const loggedInUser = this.userService.getLoggedInUser();
    if (loggedInUser) {
      customerData.MaKH = loggedInUser.MaKH;
    }
    
    this.app.editCustomerInfo(customerData.MaKH, customerData).subscribe(response => {
      console.log('Thông tin khách hàng đã được lưu thành công', response);
      this.isSaveCustomer = true;
      setTimeout(() => {
          this.isSaveCustomer = false;
      }, 2000);
      if (customerData.HinhAnh) {
        this.userService.setAvatar(customerData.HinhAnh);
      }

    }, error => {
      console.error('Lỗi khi lưu thông tin khách hàng', error);
    });
  }
}
