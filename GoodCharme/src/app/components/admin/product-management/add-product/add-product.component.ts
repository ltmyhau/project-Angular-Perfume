import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { AppService } from '../../../../services/app.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {

  file: any;
  productUrl: string = '/assets/images/perfume.png';
  productTypes: any=[];

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router,
    private location: Location
  ) { }

  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    this.app.productsTypeList().subscribe(res => {
      this.productTypes = res;
    });
  }

  positiveNumberValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
      if (value && (isNaN(value) || value <= 0)) {
        return { positiveNumber: true };
      }
      return null;
    };
  }

  submited: boolean = false;
  productAdd = this.fb.group({
    MaSP: [''],
    TenSP: ['', Validators.required],
    MaLoaiSP: ['', Validators.required],
    GiaBan: ['', [Validators.required, this.positiveNumberValidator()]],
    DungTich: ['', [Validators.required, this.positiveNumberValidator()]],
    SoLuongTon: ['', [Validators.required, this.positiveNumberValidator()]],
    HinhSP: [''],
    MoTa: ['']
  });

  get f() {return this.productAdd.controls}
  onSubmit(): any {
    this.submited = true;
    if(this.productAdd.invalid) {return false;}

    console.log(this.productAdd.value);
    this.app.addProduct(this.productAdd.value).subscribe(res => {
      alert("Thêm sản phẩm thành công.");
      this.router.navigate(['/admin/products']);
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
      this.productUrl = reader.result as string;
    };
    reader.readAsDataURL(file);    
  }

  updateImageInForm(file: File): void {
    const reader = new FileReader();
    reader.onload = () => {
      const imageUrl = reader.result as string;
      this.productAdd.patchValue({
        HinhSP: imageUrl
      });
    };
    reader.readAsDataURL(file);
  }
}
