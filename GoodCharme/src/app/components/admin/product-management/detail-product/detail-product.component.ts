import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { AppService } from '../../../../services/app.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail-product',
  templateUrl: './detail-product.component.html',
  styleUrl: './detail-product.component.css'
})
export class DetailProductComponent {
  product: any;
  
  constructor( 
    private app: AppService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    const productId = this.route.snapshot.paramMap.get('id');
    this.app.productsByMaSP(productId).subscribe((res: any) => {
      this.product = res[0];
      console.log(this.product);
    });
  }
}