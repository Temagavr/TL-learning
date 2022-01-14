import { Component, Input } from '@angular/core';
import { UserInfoDto } from '../user-info-dto';

@Component({
  selector: 'app-user-info-card',
  templateUrl: './user-info-card.component.html',
  styleUrls: ['./user-info-card.component.css']
})
export class UserInfoCardComponent {
  constructor(
  ) {

  }

  @Input() userInfo: UserInfoDto;

  changeVisibility() {
    event.preventDefault();
    var passwordInput = document.getElementById("user_password_card") as HTMLInputElement;
    if (passwordInput.type == "password") {
      passwordInput.type = "text";
    } else {
      passwordInput.type = "password";
    }
  }
}
