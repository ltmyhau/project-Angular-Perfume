import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { Location } from '@angular/common';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css'
})
export class AddEmployeeComponent {

  employeeId: string = '';
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
  employeeInfoForm = this.fb.group({
    MaNV: [''],
    HoTenNV: ['', Validators.required],
    GioiTinh: ['Nam'],
    NgaySinh: ['', [Validators.required]],
    NgayVaoLam: ['', [Validators.required]],
    DienThoai: ['', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]],
    Email: ['', [Validators.required, Validators.email]],
    DiaChi: ['', Validators.required],
    HinhAnh: ['']
  });

  get f() {return this.employeeInfoForm.controls}
  onSubmit(): any {
    this.submited = true;
    if(this.employeeInfoForm.invalid) {return false;}

    console.log(this.employeeInfoForm.value);
    this.app.addEmployee(this.employeeInfoForm.value).subscribe(res => {
      alert("Thêm nhân viên thành công.");
      this.router.navigate(['/admin/employees']);
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
      this.employeeInfoForm.patchValue({
        HinhAnh: imageUrl
      });
    };
    reader.readAsDataURL(file);
  }
}
