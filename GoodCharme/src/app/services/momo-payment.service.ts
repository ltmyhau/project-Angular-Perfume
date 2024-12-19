import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MomoPaymentService {
  private apiUrl = 'http://localhost:5000/payment';

  constructor(
    private http: HttpClient
  ) { }
  
  createMoMoPayment(orderId: string, amount: number, orderInfo: string): Observable<any> {
    const paymentData = { orderId, amount, orderInfo };
    return this.http.post(this.apiUrl, paymentData, {
      headers: { 'Content-Type': 'application/json' },
    });
  }
}
