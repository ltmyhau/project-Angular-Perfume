import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  loggedInUser: { username: string, password: string, PhanQuyen: string, MaKH: string } | null = null;
  private avatarSubject = new BehaviorSubject<string>('/assets/images/user-avatar.png');

  constructor() { }

  setLoggedInUser(username: string, password: string, PhanQuyen: string, MaKH: string ): void {
    this.loggedInUser = { username, password, PhanQuyen, MaKH };
  }

  getLoggedInUser(): { username: string, password: string, PhanQuyen: string, MaKH: string } | null {
    return this.loggedInUser;
  }

  getAvatar(): string {
    return this.avatarSubject.getValue();
  }

  setAvatar(avatarUrl: string): void {
    this.avatarSubject.next(avatarUrl);
  }

  avatar$ = this.avatarSubject.asObservable();
}
