import { Component, EventEmitter, Input, Output } from '@angular/core';
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

  @Output() changeNameEvent = new EventEmitter();

  @Output() changeUsernameEvent = new EventEmitter();

  @Output() changePasswordEvent = new EventEmitter();

  @Output() changeUserDescriptionEvent = new EventEmitter();

  staticUserInfo: UserInfoDto = {
    login: "",
    name: "",
    description: "",
    password: "abc",
    favouritesCount: 0,
    likesCount: 0,
    recipesCount: 0
  };

  ngOnInit() {

  }

  changeVisibility() {
    event.preventDefault();
    var visibilityIcon = document.getElementById("visibilityIcon");
    var passwordInput = document.getElementById("user_password_card") as HTMLInputElement;
    if (passwordInput.type == "password") {
      passwordInput.type = "text";
      visibilityIcon.classList.add('view');
    } else {
      passwordInput.type = "password";
      visibilityIcon.classList.remove('view');
    }
  }

  changeLogin() {
    let loginInput = document.getElementById("user_login_card");
    if (this.userInfo.login.length > 3) {
      this.changeUsernameEvent.emit();
    } else {
      this.showError(loginInput);
    }
  }

  changeName() {
    let nameInput = document.getElementById("user_name_card");
    if (this.userInfo.name.length > 2) {
      this.changeNameEvent.emit();
    } else {
      this.showError(nameInput);
    }
  }

  changeDescription() {
    this.changeUserDescriptionEvent.emit();
  }

  changePassword() {
    let passwordInput = document.getElementById("user_password_card");
    if (this.userInfo.password.length > 7) {
      this.changePasswordEvent.emit();
    } else {
      this.showError(passwordInput);
    }
  }

  showError(container: HTMLElement) {
    container.style['border-color'] = '#FF0000';
    container.setAttribute('onclick', 'this.style=""');
  }

}
