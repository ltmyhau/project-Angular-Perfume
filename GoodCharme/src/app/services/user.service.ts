import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  loggedInUser: { username: string, PhanQuyen: string, MaKH: string } | null = null;

  constructor() { }

  setLoggedInUser(username: string, PhanQuyen: string, MaKH: string ): void {
    this.loggedInUser = { username, PhanQuyen, MaKH };
  }

  getLoggedInUser(): { username: string, PhanQuyen: string, MaKH: string } | null {
    return this.loggedInUser;
  }

}
