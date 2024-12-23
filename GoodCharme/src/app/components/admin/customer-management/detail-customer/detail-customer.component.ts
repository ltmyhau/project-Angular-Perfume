import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-detail-customer',
  templateUrl: './detail-customer.component.html',
  styleUrl: './detail-customer.component.css'
})
export class DetailCustomerComponent {

  customer: any;

  constructor( 
    private app: AppService,
    private route: ActivatedRoute,
    private location: Location
  ) {}
  
  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    const customerId = this.route.snapshot.paramMap.get('id');
    this.app.customerByID(customerId).subscribe((res: any) => {
      this.customer = res[0];
    });
  }
}
