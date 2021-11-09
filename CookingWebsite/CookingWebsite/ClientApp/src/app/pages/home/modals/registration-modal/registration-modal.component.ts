import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-registration-modal',
  templateUrl: './registration-modal.component.html',
  styleUrls: ['./registration-modal.component.css']

})

export class RegistrationModalComponent {

  @Output() registrationToggle = new EventEmitter();

  @Output() switchToLogin = new EventEmitter();

  closeModal() {
    this.registrationToggle.emit();
  }

  switchModal() {
    this.switchToLogin.emit();
  }
}
