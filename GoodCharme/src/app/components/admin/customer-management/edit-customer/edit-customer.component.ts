import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { Location } from '@angular/common';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrl: './edit-customer.component.css'
})
export class EditCustomerComponent {
  customerId: string = '';
  avatarUrl: string = '/assets/images/user-avatar.png';

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router,
    private location: Location,    
    private activatedRoute: ActivatedRoute
  ) {}
  
  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(query => {
      let id = query.get("id");
      this.app.customerByID(id).subscribe((res: any[]) => {
        console.log(res);
        res.forEach(customer => {
          const formattedNgaySinh = new Date(customer.NgaySinh + 'Z').toISOString().slice(0, 10);
          this.customerInfoForm = this.fb.group({
            MaKH: [customer.MaKH],
            HoTenKH: [customer.HoTenKH, Validators.required],
            GioiTinh: [customer.GioiTinh],
            NgaySinh: formattedNgaySinh,
            DienThoai: [customer.DienThoai, [Validators.required, Validators.pattern(/^[0-9]{10}$/)]],
            Email: [customer.Email, [Validators.required, Validators.email]],
            DiaChi: [customer.DiaChi, Validators.required],
            Phuong: [customer.Phuong, Validators.required],
            Quan: [customer.Quan, Validators.required],
            ThanhPho: [customer.ThanhPho, Validators.required],
            HinhAnh: [customer.HinhAnh]
          });
          this.avatarUrl = customer.HinhAnh;
        });
      });
    });
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
    this.app.editCustomer(this.customerInfoForm.value).subscribe(res => {
      alert("Cập nhập khách hàng thành công.");
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