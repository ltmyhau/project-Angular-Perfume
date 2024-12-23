import { Component } from '@angular/core';
import { AppService } from '../../../../services/app.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail-employee',
  templateUrl: './detail-employee.component.html',
  styleUrl: './detail-employee.component.css'
})
export class DetailEmployeeComponent {

  employee: any;

  constructor( 
    private app: AppService,
    private route: ActivatedRoute,
    private location: Location
  ) {}
  
  goBack(): void {
    this.location.back();
  }

  ngOnInit(): void {
    const employeeId = this.route.snapshot.paramMap.get('id');
    this.app.employeeByID(employeeId).subscribe((res: any) => {
      this.employee = res[0];
    });
  }
}
