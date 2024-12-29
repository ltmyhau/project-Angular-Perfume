import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { AppService } from '../../../../services/app.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail-product-type',
  templateUrl: './detail-product-type.component.html',
  styleUrl: './detail-product-type.component.css'
})
export class DetailProductTypeComponent {

  productType: any;
  
  constructor( 
    private app: AppService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    const productTypeId = this.route.snapshot.paramMap.get('id');
    this.app.productTypeById(productTypeId).subscribe((res: any) => {
      this.productType = res[0];
    });
  }
}
