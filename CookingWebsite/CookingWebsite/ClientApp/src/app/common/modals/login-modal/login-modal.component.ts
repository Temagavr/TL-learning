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
    // тут, например, можно чистить логин пароль если надо
    this.isShowed = true;
    this.onShow.emit();
  }

  switchToRegistration() {
    this.close();
    this.onSwitchToRegistration.emit();
  }

  login() {
    console.log(`${this.loginData.login}, ${this.loginData.password}`)
    this.onLoginClick.emit(this.loginData);
  }

}
