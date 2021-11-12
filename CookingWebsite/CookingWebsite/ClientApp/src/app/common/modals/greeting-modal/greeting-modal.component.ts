import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-greeting-modal',
  templateUrl: './greeting-modal.component.html',
  styleUrls: ['./greeting-modal.component.css']

})
export class GreetingModalComponent {
  isShowedGreeting = false;

  @Output() onClose = new EventEmitter();

  @Output() onShow = new EventEmitter();

  @Output() onSwitchToRegistration = new EventEmitter();

  @Output() onSwitchToLogin = new EventEmitter();

  close() {
    this.isShowedGreeting = false;
    this.onClose.emit();
  }

  show() {
    // тут, например, можно чистить логин пароль если надо
    this.isShowedGreeting = true;
    this.onShow.emit();
  }

  switchToRegistration() {
    this.close();
    this.onSwitchToRegistration.emit();
  }

  switchToLogin() {
    this.close();
    this.onSwitchToLogin.emit();
  }
}
