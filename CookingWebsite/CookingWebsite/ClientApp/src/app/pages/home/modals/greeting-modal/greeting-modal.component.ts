import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-greeting-modal',
  templateUrl: './greeting-modal.component.html',
  styleUrls: ['./greeting-modal.component.css']

})
export class GreetingModalComponent {

  @Output() greetingToggle = new EventEmitter();

  @Output() switchToLogin = new EventEmitter();

  @Output() switchToRegistration = new EventEmitter();

  closeModal() {
    this.greetingToggle.emit();
  }

  switchLogin() {
    this.switchToLogin.emit();
  }

  switchRegistration() {
    this.switchToRegistration.emit();
  }

}
