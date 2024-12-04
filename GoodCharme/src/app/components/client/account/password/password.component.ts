import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../../../services/user.service';
import { AppService } from '../../../../services/app.service';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrl: './password.component.css'
})
export class PasswordComponent {
  changePasswordForm!: FormGroup;
  passwordIncorrect = false; 

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private app: AppService
  ) {}

  ngOnInit(): void {
    this.changePasswordForm = this.fb.group({
      MatKhauHT: ['', [Validators.required]],
      MatKhauMoi: ['', [Validators.required, Validators.minLength(6), this.passwordComplexityValidator()]],
      XNMatKhauMoi: ['', [Validators.required]]
    }, {
      validator: this.mustMatch('MatKhauMoi', 'XNMatKhauMoi')
    });
  }

  passwordComplexityValidator() {
    return (control: any) => {
      const value = control.value || '';
      const hasUpperCase = /[A-Z]/.test(value);
      const hasSpecialCharacter = /[!@#$%^&*(),.?":{}|<>]/.test(value);
      const isValid = hasUpperCase && hasSpecialCharacter;

      return isValid ? null : { passwordComplexity: true };
    };
  }

  mustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors['mustMatch']) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }

  get f() {
    return this.changePasswordForm.controls;
  }

  isChangePassword: boolean = false;

  onSubmit(): void {
    if (this.changePasswordForm.invalid) {
      Object.keys(this.changePasswordForm.controls).forEach(key => {
        this.changePasswordForm.controls[key].markAsTouched();
      });
      return;
    }
    const currentPassword = this.changePasswordForm.value.MatKhauHT;
    const loggedInUser = this.userService.getLoggedInUser();

    if (loggedInUser && loggedInUser.password === currentPassword) {
      this.passwordIncorrect = false;
      console.log('Mật khẩu hiện tại chính xác, tiếp tục xử lý...');

      const newPassword = this.changePasswordForm.value.MatKhauMoi;
      this.app.updatePassword(loggedInUser.username, newPassword).subscribe(response => {
        this.isChangePassword = true;
        if (loggedInUser) {
          loggedInUser.password = newPassword;
          this.userService.setLoggedInUser(loggedInUser.username, newPassword, loggedInUser.PhanQuyen, loggedInUser.MaKH);
        }
        this.changePasswordForm.reset();
        setTimeout(() => {
            this.isChangePassword = false;
        }, 2000);
        },
        error => {
          console.error('Có lỗi xảy ra trong quá trình cập nhật mật khẩu.');
        }
      );

    } else {
      this.passwordIncorrect = true;
      this.f['MatKhauHT'].setErrors({ incorrectPassword: true });
    }
  }
}
