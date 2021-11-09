import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-greeting',
  templateUrl: './greeting.component.html',
  styleUrls: ['./greeting.component.css']
})
export class GreetingComponent {
  @Output() openGreeting = new EventEmitter();

  @Output() openLogin = new EventEmitter();

  openGreetingModal() {
    this.openGreeting.emit();
  }

  openLoginModal() {
    this.openLogin.emit();
  }
}
