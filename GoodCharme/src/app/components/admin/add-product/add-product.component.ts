import { Component } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {

  file: any;
  preview: any;
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

  selectFile(event: any) {
    this.file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(this.file);
    reader.onload = (e:any) => {
      this.preview = e.target.result;
      this.productAdd.patchValue({
        HinhSP: this.preview
    });
    }
  }

  ngOnInit(): void {
    this.app.productsTypeList().subscribe(res => {
      this.productTypes = res;
    });
  }

  submited: boolean = false;
  productAdd = this.fb.group({
    MaSP: [''],
    TenSP: ['', Validators.required],
    MaLoaiSP: ['', Validators.required],
    GiaBan: ['', Validators.required],
    SoLuongTon: ['', Validators.required],
    HinhSP: []
  });

  get f() {return this.productAdd.controls}
  onSubmit(): any {
    this.submited = true;
    if(this.productAdd.invalid) {return false;}

    console.log(this.productAdd.value);
    this.app.addProduct(this.productAdd.value).subscribe(res => {
      alert("Thêm sản phẩm thành công.");
      this.router.navigate(['/admin/product']);
    })
  }
}
