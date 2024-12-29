import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { FormBuilder, Validators, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-discount',
  templateUrl: './edit-discount.component.html',
  styleUrl: './edit-discount.component.css'
})
export class EditDiscountComponent {
  customerId: string = '';

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
      this.app.discountById(id).subscribe((res: any[]) => {
        res.forEach(discount => {
          this.discountForm = this.fb.group({
            MaKM: [discount.MaKM],
            Code: [discount.Code, [Validators.required, this.noSpecialCharactersValidator()]],
            NgayTao: [discount.NgayTao],
            LoaiKM: [discount.LoaiKM, Validators.required],
            UuDai: [discount.UuDai, [Validators.required, this.positiveNumberValidator()]],
            NgayBD: [discount.NgayBD, Validators.required],
            NgayKT: [discount.NgayKT, Validators.required],
            TrangThai: [discount.TrangThai]
          });
        });
      });
    });
  }

  noSpecialCharactersValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
      if (!value) {
        return null;
      }
      const forbidden = /[^a-zA-Z0-9_]/.test(value);
      return forbidden ? { invalidCharacters: true } : null;
    };
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
  discountForm = this.fb.group({
    MaKM: [''],
    Code: ['', [Validators.required, this.noSpecialCharactersValidator()]],
    NgayTao: [''],
    LoaiKM: ['', Validators.required],
    UuDai: ['', [Validators.required, this.positiveNumberValidator()]],
    NgayBD: ['', Validators.required],
    NgayKT: ['', Validators.required],
    TrangThai: ['']
  });

  get f() {return this.discountForm.controls}
  onSubmit(): any {
    this.submited = true;
    if(this.discountForm.invalid) {return false;}
    
    this.app.editDiscount(this.discountForm.value).subscribe(res => {
      alert("Cập nhập khuyến mãi thành công.");
      this.router.navigate(['/admin/discounts']);
    })
  }
}
