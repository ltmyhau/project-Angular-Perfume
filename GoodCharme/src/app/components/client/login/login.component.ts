import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginService } from '../../../services/login.service';
import { Router } from '@angular/router';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm : FormGroup = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', Validators.required)
  });

  constructor (
    private loginService: LoginService,
    private router: Router,
    private userService: UserService
   ){}

  onLogin(): void {
    if (this.loginForm.invalid) {return;}
    console.log(this.loginForm.value);
    this.loginService.login(this.loginForm.value).subscribe((res: any) => {
      console.log(res);
      if (res && res.length > 0) {
        const loggedInUser = res[0];
        this.userService.setLoggedInUser(res[0].Username, res[0].PhanQuyen, res[0].MaKH);
        if (loggedInUser.PhanQuyen === 'admin') {
          this.router.navigate(['/admin']);
        } else {
          this.router.navigate(['/']);
        }    
      } else {
        alert("Tên đăng nhập hoặc mật khẩu không chính xác.");
      }
    });
  }

}
