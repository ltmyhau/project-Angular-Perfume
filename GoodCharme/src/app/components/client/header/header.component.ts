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

}
