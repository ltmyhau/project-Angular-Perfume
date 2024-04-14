import { Component } from '@angular/core';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-order-tracking',
  templateUrl: './order-tracking.component.html',
  styleUrl: './order-tracking.component.css'
})
export class OrderTrackingComponent {
  giamGia: number = 0;
  phiVanChuyen: number = 25000;
  tongThanhTien: number = 0;

  constructor( private cartServece:CartService) {}
  items = this.cartServece.getItems();
  tongTien(){
    let sum: number = 0;
    this.items.forEach( items => sum += items.soLuong * items.giaBan);
    return sum;
  }
  tongSoLuong(){
    let sum: number = 0;
    this.items.forEach( items => sum += items.soLuong);
    return sum;
  }
  tongThanhToan(){
    let sum: number = 0;
    sum = this.tongTien() - this.giamGia + this.phiVanChuyen;
    return sum;
  }
}
