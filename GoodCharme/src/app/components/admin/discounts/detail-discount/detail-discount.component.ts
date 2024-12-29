import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '../../../../services/app.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-detail-discount',
  templateUrl: './detail-discount.component.html',
  styleUrl: './detail-discount.component.css'
})
export class DetailDiscountComponent {

  discount: any;

  constructor(
    private app: AppService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    const discountId = this.route.snapshot.paramMap.get('id');
    this.app.discountById(discountId).subscribe((res: any) => {
      this.discount = res[0];
    });
  }
}
