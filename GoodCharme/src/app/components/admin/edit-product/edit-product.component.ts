import { Component, OnInit } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent implements OnInit {

  file: any;
  preview: any;
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

  selectFile(event: any) {
    this.file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(this.file);
    reader.onload = (e:any) => {
      this.preview = e.target.result;
      this.productEdit.patchValue({
        HinhSP: this.preview
    });
    }
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
            GiaBan: [product.GiaBan, Validators.required],
            SoLuongTon: [product.SoLuongTon, Validators.required],
            HinhSP: [product.HinhSP]
          });
          this.preview = product.HinhSP;
        });
      });
    });
  }

  submited: boolean = false;
  productEdit = this.fb.group({
    MaSP: [''],
    TenSP: ['', Validators.required],
    MaLoaiSP: ['', Validators.required],
    GiaBan: ['', Validators.required],
    SoLuongTon: ['', Validators.required],
    HinhSP: []
  });

  get f() {return this.productEdit.controls}
  onUpdate(): any {
    this.submited = true;
    if(this.productEdit.invalid) {return false;}
    
    console.log(this.productEdit.value);
    this.app.editProduct(this.productEdit.value).subscribe(res => {
      alert("Cập nhập sản phẩm thành công.");
      this.router.navigate(['/admin/product']);
    })
  }
}
