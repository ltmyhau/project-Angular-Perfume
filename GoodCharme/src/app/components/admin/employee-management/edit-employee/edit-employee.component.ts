import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { Location } from '@angular/common';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.css'
})
export class EditEmployeeComponent {
  employeeId: string = '';
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
      this.app.employeeByID(id).subscribe((res: any[]) => {
        console.log(res);
        res.forEach(employee => {
          const formattedNgaySinh = new Date(employee.NgaySinh + 'Z').toISOString().slice(0, 10);
          const formattedNgayVaoLam = new Date(employee.NgayVaoLam + 'Z').toISOString().slice(0, 10);
          this.employeeInfoForm = this.fb.group({
            MaNV: [employee.MaNV],
            HoTenNV: [employee.HoTenNV, Validators.required],
            GioiTinh: [employee.GioiTinh],
            NgaySinh: formattedNgaySinh,
            NgayVaoLam: formattedNgayVaoLam,
            DienThoai: [employee.DienThoai, [Validators.required, Validators.pattern(/^[0-9]{10}$/)]],
            Email: [employee.Email, [Validators.required, Validators.email]],
            DiaChi: [employee.DiaChi, Validators.required],
            HinhAnh: [employee.HinhAnh]
          });
          this.avatarUrl = employee.HinhAnh;
        });
      });
    });
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
    this.app.editEmployee(this.employeeInfoForm.value).subscribe(res => {
      alert("Cập nhập nhân viên thành công.");
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
