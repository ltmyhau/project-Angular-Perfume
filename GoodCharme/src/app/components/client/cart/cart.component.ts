import { Component } from '@angular/core';
import { CartService } from '../../../services/cart.service';
import { Cart } from '../../../interface/cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  constructor( private cartService:CartService) {}
  items = this.cartService.getItems();

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

  xoaSanPhamKhoiGioHang(sanPham: Cart) {
    this.cartService.removeFromCart(sanPham);
  }
}
