import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  loggedInUsername: string | undefined;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    const loggedInUser = this.userService.getLoggedInUser();
    console.log(loggedInUser);
    if (loggedInUser) {
      this.loggedInUsername = loggedInUser.username;
    }
  }

  searchTerm?: string;
  onSubmit() {
    if (this.searchTerm !== undefined) {
      // this.app.searchProduct(this.searchTerm).subscribe((res: any) => {
        
      // })
    }
  }

  // if (this.tuGia !== undefined && this.denGia !== undefined) {
  //   this.app.productsByPrice(this.tuGia, this.denGia).subscribe((res: any) => {
  //     this.products = res;
  //   });
  // }
}
