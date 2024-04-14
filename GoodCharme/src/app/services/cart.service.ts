import { Injectable } from '@angular/core';
import { Cart } from '../interface/cart';
import { Product } from '../interface/product';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor( private http:HttpClient ) { }
  items: Cart[] = [];
  addToCart(sanPham: Product, quantity: number = 1) {
    var index = this.items.findIndex( item => item.maSP === sanPham.MaSP);
    if (index >= 0) {
      this.items[index].soLuong++;
    }
    else {
      var c:Cart;
      c = { 
        maSP: sanPham.MaSP, 
        tenSP: sanPham.TenSP, 
        giaBan: sanPham.GiaBan, 
        hinhSP: sanPham.HinhSP, 
        soLuong: quantity
      }
      this.items.push(c); 
    }
  }

  getItems() { return this.items; }

  clearCart() { this.items = []; return this.items;}

  removeFromCart(product: Cart) {
    const index = this.items.findIndex(item => item.maSP === product.maSP);
    if (index >= 0) {
      this.items.splice(index, 1);
    }
  }
}
