import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']

})
export class LoginModalComponent {

  @Output() loginToggle = new EventEmitter();

  @Output() switchToRegistration = new EventEmitter();

  closeModal() {
    this.loginToggle.emit();
  }

  switchModal() {
    this.switchToRegistration.emit();
  }
}
