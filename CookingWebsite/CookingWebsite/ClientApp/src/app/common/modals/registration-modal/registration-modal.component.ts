import { Component, Output, EventEmitter } from '@angular/core';
import { RegistrationDto } from '../../../Dtos/registration-dto';

@Component({
  selector: 'app-registration-modal',
  templateUrl: './registration-modal.component.html',
  styleUrls: ['./registration-modal.component.css']

})

export class RegistrationModalComponent {

  isShowedRegistration = false;

  public registrationInfo: RegistrationDto;

  @Output() onClose = new EventEmitter();

  @Output() onShow = new EventEmitter();

  @Output() onSwitchToLogin = new EventEmitter();

  @Output() onRegistrationClick = new EventEmitter();

  constructor() {
    this.registrationInfo = {} as RegistrationDto;
  }

  close() {
    event.preventDefault();
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
    this.onRegistrationClick.emit(this.registrationInfo);
  }
}
