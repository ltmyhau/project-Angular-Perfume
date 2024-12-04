import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

    constructor(
        private authService: AuthService,
        private router: Router
    ) {}

    // canActivate(route: any): boolean {
    //     const expectedRole = route.data.role;
    //     if (this.authService.isLoggedIn() && this.authService.hasRole(expectedRole)) {
    //         return true;
    //     }
    //     this.router.navigate(['/access-denied']);
    //     return false;
    // }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        const expectedRole = route.data['role'];
        const userRole = this.authService.getUserRole();
    
        if (this.authService.isLoggedIn() && userRole === expectedRole) {
          return true;
        }
    
        this.router.navigate(['/login']); // Điều hướng nếu không đủ quyền
        return false;
    }
}
