import { Component } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-employee-management',
  templateUrl: './employee-management.component.html',
  styleUrl: './employee-management.component.css'
})
export class EmployeeManagementComponent {
  employees: any=[];
  currentPage: number = 1;
  totalItems: number = 0;
  totalPages: number = 0;
  pageSize: number = 20;

  constructor( 
    private app: AppService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadCutomers();
  }

  loadCutomers():void {
    this.app.employeesList().subscribe((res: any) => {
      this.employees = res;
      this.calculatePagination(res.length);
    });
  }
  
  onDelete(employeeId: string) {
    const confirmDelete = confirm("Bạn có chắc chắn muốn xóa nhân viên này?");
    if (confirmDelete) {
      this.app.deleteEmployee(employeeId).subscribe(res => {
        this.app.employeesList().subscribe((res: any) => {
          this.employees = res;
        });
        alert("Xóa nhân viên thành công.");
      });
    }
  }

  calculatePagination(totalItems: number): void {
    this.totalItems = totalItems;
    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
  }

  goToFirstPage() {
    this.currentPage = 1;
    this.loadCutomers();
    this.preventScrollToTop();
  }

  goToLastPage() {
    this.currentPage = this.totalPages;
    this.loadCutomers();
    this.preventScrollToTop();
  }

  preventScrollToTop() {
    window.scrollTo(0, document.body.scrollTop);
  }

  get isSinglePage(): boolean {
    return this.totalPages <= 1;
  }

  sortColumn: string = '';
  sortDirection: string = 'desc';

  sortEmployees(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'desc';
    }

    this.employees.sort((a: any, b: any) => {
      const valueA = a[column];
      const valueB = b[column];
      if (valueA < valueB) return this.sortDirection === 'asc' ? -1 : 1;
      if (valueA > valueB) return this.sortDirection === 'asc' ? 1 : -1;
        return 0;
    });
  }
}
