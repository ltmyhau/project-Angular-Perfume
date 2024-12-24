import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { LoginService } from '../../../services/login.service';
import { Router } from '@angular/router';
import { UserService } from '../../../services/user.service';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  showPassword: boolean = false;
  loginError: boolean = false;

  constructor (
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    private userService: UserService
   ){
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
      rememberPassword: [false]
    });
   }

  ngOnInit(): void {
    const savedUsername = localStorage.getItem('username');
    const savedPassword = localStorage.getItem('password');
    if (savedUsername && savedPassword) {
      this.loginForm.patchValue({
        username: savedUsername,
        password: atob(savedPassword),
        rememberPassword: true
      });
    }
  }

  onLogin(): void {    
    // if (this.loginForm.invalid) {return;}
    if (this.loginForm.invalid) {
      this.loginError = true;

      this.loginForm.controls['username'].setErrors({ invalid: true });
      this.loginForm.controls['password'].setErrors({ invalid: true });
      return;
    }
    
    this.loginService.login(this.loginForm.value).subscribe((res: any) => {
      if (res && res.length > 0) {
        const loggedInUser = res[0];

        this.userService.setLoggedInUser(res[0].Username, res[0].Password, res[0].PhanQuyen, res[0].MaKH);

        if (this.loginForm.value.rememberPassword) {
          localStorage.setItem('username', loggedInUser.Username);
          localStorage.setItem('password', btoa(loggedInUser.Password));
        } else {
            localStorage.removeItem('username');
            localStorage.removeItem('password');
        }

        if (loggedInUser.PhanQuyen === 'admin') {
          this.router.navigate(['/admin/dashboard']);
        } else {
          this.router.navigate(['/']);
        }
      } else {
        // alert("Tên đăng nhập hoặc mật khẩu không chính xác.");
        this.loginError = true;
        this.loginForm.controls['username'].setErrors({ invalid: true });
        this.loginForm.controls['password'].setErrors({ invalid: true });
      }
    });
  }

  clearError(): void {
    this.loginError = false;
    this.loginForm.controls['username'].setErrors(null);
    this.loginForm.controls['password'].setErrors(null);
  }

  togglePasswordVisibility(): void {
      this.showPassword = !this.showPassword;
  }
}
