import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-product-type',
  templateUrl: './edit-product-type.component.html',
  styleUrl: './edit-product-type.component.css'
})
export class EditProductTypeComponent {

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
      this.app.productTypeById(id).subscribe((res: any[]) => {
        res.forEach(productType => {
          this.productTypeForm = this.fb.group({
            MaLoaiSP: [productType.MaLoaiSP],
            TenLoaiSP: [productType.TenLoaiSP, Validators.required],
          });
        });
      });
    });
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

    this.app.editProductType(this.productTypeForm.value).subscribe(res => {
      alert("Cập nhật loại sản phẩm thành công.");
      this.router.navigate(['/admin/products-type']);
    })
  }
}
