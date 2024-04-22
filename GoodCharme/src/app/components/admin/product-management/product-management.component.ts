import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html',
  styleUrl: './product-management.component.css'
})
export class ProductManagementComponent {

  products: any=[];

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.app.productsList().subscribe((res: any) => {
      this.products = res;
    });
  }

  submited: boolean = false;
  productAdd = this.fb.group({
    MaSP: [''],
    TenSP: ['', Validators.required],
    MaLoaiSP: ['', Validators.required],
    GiaBan: ['', Validators.required],
    SoLuongTon: ['', Validators.required]
  });

  get f() {return this.productAdd.controls}
  onSubmit(): any {
    this.submited = true;
    if(this.productAdd.invalid) {return false;}

    console.log(this.productAdd.value);
    this.app.addProduct(this.productAdd.value).subscribe(res => {
      this.router.navigate(['/admin']);
    })
  }

  onDelete(productId: number) {
    const confirmDelete = confirm("Bạn có chắc chắn muốn xóa sản phẩm này?");
    if (confirmDelete) {
      console.log(productId);
      this.app.deleteProduct(productId).subscribe(res => {
        this.app.productsList().subscribe((res: any) => {
          this.products = res;
        });
        alert("Xóa sản phẩm thành công.");
        this.app.productsList().subscribe((res: any) => {
          this.products = res;
        });
      });
    }
  }
}
