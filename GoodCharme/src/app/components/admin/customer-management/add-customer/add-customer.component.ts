import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrl: './add-customer.component.css'
})
export class AddCustomerComponent {
  customerId: string = '';
  avatarUrl: string = '/assets/images/user-avatar.png';

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router,
    private location: Location
  ) {}
  
  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    
  }

  submited: boolean = false;
  customerInfoForm = this.fb.group({
    MaKH: [''],
    HoTenKH: ['', Validators.required],
    GioiTinh: ['Nam'],
    NgaySinh: ['', [Validators.required]],
    DienThoai: ['', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]],
    Email: ['', [Validators.required, Validators.email]],
    DiaChi: ['', Validators.required],
    Phuong: ['', Validators.required],
    Quan: ['', Validators.required],
    ThanhPho: ['', Validators.required],
    HinhAnh: ['']
  });

  get f() {return this.customerInfoForm.controls}
  onSubmit(): any {
    this.submited = true;
    if(this.customerInfoForm.invalid) {return false;}

    console.log(this.customerInfoForm.value);
    this.app.addCustomer(this.customerInfoForm.value).subscribe(res => {
      alert("Thêm khách hàng thành công.");
      this.router.navigate(['/admin/customers']);
    })
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
}