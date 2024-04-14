import { Component, OnInit } from '@angular/core';
import { AppService } from '../../services/app.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent implements OnInit {
  constructor( private app:AppService ){}

  table: any = [];
  nguoiDung: any = {
    tenDangNhap: "",
    matKhau: "",
    phanQuyen: ""
  }

  ngOnInit(): void {
    this.dangNhap();
  }

  dangNhap() {
    this.app.login(this.nguoiDung).subscribe(data => {
      this.table = data;
    })
  }
}
