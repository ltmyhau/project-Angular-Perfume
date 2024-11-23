import { Injectable } from '@angular/core';
import { Cart } from '../interface/cart';
import { Product } from '../interface/product';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartCountSubject = new BehaviorSubject<number>(0);
  cartCount$ = this.cartCountSubject.asObservable();

  constructor(private http: HttpClient) { }
  items: Cart[] = [];
  addToCart(sanPham: Product, quantity: number = 1) {
    var index = this.items.findIndex(item => item.maSP === sanPham.MaSP);
    if (index >= 0) {
      this.items[index].soLuong++;
    }
    else {
      var c: Cart;
      c = {
        maSP: sanPham.MaSP,
        tenSP: sanPham.TenSP,
        giaBan: sanPham.GiaBan,
        hinhSP: sanPham.HinhSP,
        soLuong: quantity
      }
      this.items.push(c);
    }
    this.updateCartCount();
  }

  getItems() { return this.items; }

  clearCart() { this.items = []; return this.items; }

  removeFromCart(product: Cart) {
    const index = this.items.findIndex(item => item.maSP === product.maSP);
    if (index >= 0) {
      this.items.splice(index, 1);
    }
    this.updateCartCount();
  }

  private updateCartCount() {
    const count = this.items.length; 
    this.cartCountSubject.next(count);
  }

  getItemCount() {
    return this.cartCountSubject.value;
  }
  
}
