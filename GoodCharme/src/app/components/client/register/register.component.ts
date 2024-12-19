import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  passwordVisibility: { [key: string]: boolean } = {
    password: false,
    passwordConfirmation: false
  };

  toggleVisibility(field: string): void {
      this.passwordVisibility[field] = !this.passwordVisibility[field];
  }
}
