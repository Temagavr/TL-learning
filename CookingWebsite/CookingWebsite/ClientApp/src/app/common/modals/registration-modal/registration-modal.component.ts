import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-registration-modal',
  templateUrl: './registration-modal.component.html',
  styleUrls: ['./registration-modal.component.css']

})

export class RegistrationModalComponent {

  isShowedRegistration = false;

  @Output() onClose = new EventEmitter();

  @Output() onShow = new EventEmitter();

  @Output() onSwitchToLogin = new EventEmitter();

  @Output() onRegistrationClick = new EventEmitter();

  close() {
    this.isShowedRegistration = false;
    this.onClose.emit();
  }

  show() {
    this.isShowedRegistration = true;
    this.onShow.emit();
  }

  switchToLogin() {
    this.close();
    this.onSwitchToLogin.emit();
  }

  registration() {
    this.onRegistrationClick.emit();
  }
}
