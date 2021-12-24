import { Component, Output, EventEmitter } from '@angular/core';
import { LoginDto } from '../../../Dtos/login-dto';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']

})
export class LoginModalComponent {

  public loginData: LoginDto;

  isShowed = false;

  @Output() onClose = new EventEmitter();

  @Output() onShow = new EventEmitter();

  @Output() onSwitchToRegistration = new EventEmitter();

  @Output() onLoginClick = new EventEmitter();

  constructor() {
    this.loginData = {} as LoginDto;
  }

  close() {
    event.preventDefault();
    this.isShowed = false;
    this.onClose.emit();
  }

  show() {
    this.isShowed = true;
    this.onShow.emit();
  }

  switchToRegistration() {
    this.close();
    this.onSwitchToRegistration.emit();
  }

  loginError() {
    let loginInput = document.getElementById('login');
    let passwordInput = document.getElementById('password');

    this.showError(loginInput);
    this.showError(passwordInput);
  }

  validate(): boolean {
    let error = false;
    const loginInput = document.getElementById('login');
    const passwordInput = document.getElementById('password');

    if (!this.loginData.login) {
      this.showError(loginInput);
      error = true;
    }

    if (!this.loginData.password) {
      this.showError(passwordInput);
      error = true;
    }

    return error
  }

  showError(container: HTMLElement) {
    container.style['border-color'] = '#FF0000';
    container.setAttribute('onclick', 'this.style=""');
  }

  login() {
    if (!this.validate()) {
      this.onLoginClick.emit(this.loginData);
    }
  }
}
