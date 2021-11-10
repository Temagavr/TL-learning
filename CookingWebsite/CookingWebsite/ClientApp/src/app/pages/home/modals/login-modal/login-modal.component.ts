import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.css']

})
export class LoginModalComponent {
  isShowed = false;

  @Output() onClose = new EventEmitter();

  @Output() onShow = new EventEmitter();

  close() {
    this.isShowed = false;
    this.onClose.emit();
  }

  show() {
    // тут, например, можно чистить логин пароль если надо
    this.isShowed = true;
    this.onShow.emit();
  }
}
