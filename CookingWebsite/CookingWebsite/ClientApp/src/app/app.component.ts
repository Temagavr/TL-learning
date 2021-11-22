import { Component, ViewChild } from '@angular/core';
import { UserInteractionService } from './common/services/user-interaction.service';
import { AccountService } from './common/services/account.service';
import { LoginModalComponent } from './common/modals/login-modal/login-modal.component';
import { RegistrationModalComponent } from './common/modals/registration-modal/registration-modal.component';
import { GreetingModalComponent } from './common/modals/greeting-modal/greeting-modal.component';

import { RegistrationDto } from './Dtos/registration-dto';
import { LoginDto } from './Dtos/login-dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  @ViewChild(LoginModalComponent, { static: false })
  private loginModal: LoginModalComponent;

  @ViewChild(RegistrationModalComponent, { static: false })
  private registrationModal: RegistrationModalComponent;

  @ViewChild(GreetingModalComponent, { static: false })
  private greetingModal: GreetingModalComponent;

  title = 'app';

  userName = '';

  constructor(
    userInteractionService: UserInteractionService,
    private accountService: AccountService
  ) {
      userInteractionService.onOpenLoginModalRequest$.subscribe(() => {
        this.showLoginModal();
      }),
      userInteractionService.onOpenRegistrationModalRequest$.subscribe(() => {
        this.showRegistrationModal();
      }),
      userInteractionService.onOpenGreetingModalRequest$.subscribe(() => {
        this.showGreetingModal();
      })
  }

  showLoginModal() {
    this.loginModal.show();
  }

  userLogOut() {
    this.userName = '';
    console.log('User log out');
  }

  doSmthOnCloseLoginModal() {
    // Тут в closeModal можно что то делать
    console.log('login modal closed');
  }

  doSmthOnLoginClick(loginDto: LoginDto) {
    console.log('Im try to login');
    if (this.accountService.Login(loginDto)) {
      this.userName = loginDto.login;
    };
    this.loginModal.close();
  }

  doSmthOnOpenLoginModal() {
    console.log('login modal showed');
  }

  switchToRegistration() {
    this.showRegistrationModal();
  }

  switchToLogin() {
    this.showLoginModal();
  }

  showRegistrationModal() {
    this.registrationModal.show();
  }

  showGreetingModal() {
    this.greetingModal.show();
  }

  doSmthOnRegistrationClick(registrationInfo: RegistrationDto) {
    event.preventDefault();
    this.accountService.Register(registrationInfo);
    console.log('Try to registration');
    this.registrationModal.close();
  }

}
