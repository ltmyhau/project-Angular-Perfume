import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AppService } from '../../services/app.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor( private app:AppService ){}

  tenDangNhap?: string;
  matKhau?: string;
  table: any = [];
  nguoiDung: any = {
    tenDangNhap: "",
    matKhau: ""
  }

  ngOnInit(): void {

  }

  dangNhap() {
    this.nguoiDung.tenDangNhap = this.tenDangNhap;
    this.nguoiDung.matKhau = this.matKhau;
    this.app.login(this.nguoiDung).subscribe(data => {
      this.table = data;
      if (this.table[0].Column1 == 1) {
        window.location.href = "http://localhost:4200/";
      } else {
        alert("Đăng nhập thất bại");
      }
    });
  }    
}
