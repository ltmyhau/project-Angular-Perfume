import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
const api = 'http://localhost:5094/api';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http:HttpClient) { }

  getOrders():Observable<any[]> {
    return this.http.get<any>(`${api}/DonHang/GetOrders`);
  }

  getOrderById(id: any = 1):Observable<any[]> {
    return this.http.get<any>(`${api}/DonHang/GetOrderById?id=`+id);
  }

  getOrderDetailsByOrderId(orderId: string): Observable<any[]> {
    return this.http.get<any[]>(`${api}/ChiTietDonHang/${orderId}`);
  } 

//  orderByID(idSP: any = 1):Observable<any[]> {
//     return this.http.get<any>(`${api}/DonHang/GetDonHangTheoMaDH?id=`+idSP);
//   }
}
