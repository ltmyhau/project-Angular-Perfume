import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '../../../../services/app.service';


@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent implements OnInit {

  file: any;
  productUrl: string = '/assets/images/perfume.png';
  productTypes: any=[];

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router,
    private location: Location,
    private activatedRoute: ActivatedRoute
  ) { }

  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    this.app.productsTypeList().subscribe(res => {
      this.productTypes = res;
    });

    this.activatedRoute.paramMap.subscribe(query => {
      let id = query.get("id");
      this.app.productsByMaSP(id).subscribe((res: any[]) => {
        console.log(res);
        res.forEach(product => {
          this.productEdit = this.fb.group({
            MaSP: [product.MaSP],
            TenSP: [product.TenSP, Validators.required],
            MaLoaiSP: [product.MaLoaiSP, Validators.required],
            GiaBan: [product.GiaBan, [Validators.required, this.positiveNumberValidator()]],
            DungTich: [product.DungTich, [Validators.required, this.positiveNumberValidator()]],
            SoLuongTon: [product.SoLuongTon, [Validators.required, this.positiveNumberValidator()]],
            HinhSP: [product.HinhSP],
            MoTa: [product.MoTa]
          });
          this.productUrl = product.HinhSP;
        });
      });
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
  productEdit = this.fb.group({
    MaSP: [''],
    TenSP: ['', Validators.required],
    MaLoaiSP: ['', Validators.required],
    GiaBan: ['', [Validators.required, this.positiveNumberValidator()]],
    DungTich: ['', [Validators.required, this.positiveNumberValidator()]],
    SoLuongTon: ['', [Validators.required, this.positiveNumberValidator()]],
    HinhSP: [''],
    MoTa: ['']
  });

  get f() {return this.productEdit.controls}
  onUpdate(): any {
    this.submited = true;
    if(this.productEdit.invalid) {return false;}
    
    console.log(this.productEdit.value);
    this.app.editProduct(this.productEdit.value).subscribe(res => {
      alert("Cập nhập sản phẩm thành công.");
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
      this.productEdit.patchValue({
        HinhSP: imageUrl
      });
    };
    reader.readAsDataURL(file);
  }
}
