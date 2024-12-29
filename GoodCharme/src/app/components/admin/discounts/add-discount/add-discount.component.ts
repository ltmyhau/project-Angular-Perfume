import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { FormBuilder, Validators, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-discount',
  templateUrl: './add-discount.component.html',
  styleUrl: './add-discount.component.css'
})
export class AddDiscountComponent {
  customerId: string = '';

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
    console.log(this.discountForm.value)
    this.app.addDiscount(this.discountForm.value).subscribe(res => {
      alert("Thêm khuyến mãi thành công.");
      this.router.navigate(['/admin/discounts']);
    })
  }
}
