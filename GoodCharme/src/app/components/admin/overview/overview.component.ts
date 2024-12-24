import { Component } from '@angular/core';
import { AppService } from '../../../services/app.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrl: './overview.component.css'
})
export class OverviewComponent {

  statistic: any;

  constructor(
    private app: AppService,
  ) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders(): void {
    this.app.statisticOverview().subscribe((res: any) => {
      this.statistic = res[0];
    });
  }
}
  