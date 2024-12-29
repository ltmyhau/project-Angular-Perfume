import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product-type',
  templateUrl: './add-product-type.component.html',
  styleUrl: './add-product-type.component.css'
})
export class AddProductTypeComponent {

  productTypeId: string = '';

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.app.getNextProductTypeId().subscribe((id: string) => {
      this.productTypeId = id;
    });    
  }

  goBack(): void {
    this.location.back();
  }

  submited: boolean = false;
  productTypeForm = this.fb.group({
    MaLoaiSP: [''],
    TenLoaiSP: ['', Validators.required],
  });

  get f() {return this.productTypeForm.controls}
  onSubmit(): any {
    this.submited = true;
    if(this.productTypeForm.invalid) {return false;}

    this.app.addProductType(this.productTypeForm.value).subscribe(res => {
      alert("Thêm loại sản phẩm thành công.");
      this.router.navigate(['/admin/products-type']);
    })
  }
}
