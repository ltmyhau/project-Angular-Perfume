import { Component } from '@angular/core';

@Component({
  selector: 'app-payment-complete',
  templateUrl: './payment-complete.component.html',
  styleUrl: './payment-complete.component.css'
})
export class PaymentCompleteComponent {
  ngOnInit(): void {
    window.close();
  }  
}
