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

    this.registrationInfo.login = '';
    this.registrationInfo.name = '';
    this.registrationInfo.password = '';
    this.registrationInfo.repeatPassword = '';

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

  validate(): boolean {
    let error = false;
    const nameInput = document.getElementById('name');
    const loginInput = document.getElementById('registrate_login');
    const passwordInput = document.getElementById('registrate_password');
    const repeatPasswordInput = document.getElementById('repeat_password');

    if (!this.registrationInfo.name) {
      this.showError(nameInput);
      error = true;
    }

    if (!this.registrationInfo.login) {
      this.showError(loginInput);
      console.log('login empty');
      error = true;
    }

    if (!this.registrationInfo.password || this.registrationInfo.password.length < 8) {
      this.showError(passwordInput);
      this.showError(repeatPasswordInput)
      error = true;
    }

    if (!this.registrationInfo.repeatPassword || this.registrationInfo.repeatPassword != this.registrationInfo.password) {
      this.showError(passwordInput);
      this.showError(repeatPasswordInput)
      error = true;
    }

    return error;
  }

  showError(container: HTMLElement) {
    container.style['border-color'] = '#FF0000';
    container.setAttribute('onclick', 'this.style=""');
  }

  registration() {
    if (!this.validate()) {
      this.onRegistrationClick.emit(this.registrationInfo);
    }
  }
}
