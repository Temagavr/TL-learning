import { Component, ViewChild } from '@angular/core';
import { UserInteractionService } from './common/services/user-interaction.service';
import { AccountService } from './common/services/account.service';
import { LoginModalComponent } from './common/modals/login-modal/login-modal.component';
import { RegistrationModalComponent } from './common/modals/registration-modal/registration-modal.component';
import { GreetingModalComponent } from './common/modals/greeting-modal/greeting-modal.component';

import { RegistrationDto } from './Dtos/registration-dto';
import { LoginDto } from './Dtos/login-dto';
import { Router } from '@angular/router';
import { UserInfoDto } from './Dtos/user-info-dto';
import { AuthorizedUserDto } from './Dtos/authorized-user-dto';

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
    private accountService: AccountService,
    private router: Router
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

  ngOnInit() {
    this.accountService.getUser().then((user: AuthorizedUserDto) => {
      if (user) {
        this.userName = user.name;
      }
    });
  }

  showLoginModal() {
    this.loginModal.show();
  }

  userLogOut() {
    this.accountService.logout();
    this.userName = '';
    this.router.navigate(['/']);
  }

  cleanLoginModalInputs() {
    this.loginModal.loginData.login = '';
    this.loginModal.loginData.password = '';
    console.log('login modal closed');
  }

  login(loginDto: LoginDto) {
    console.log('Im try to login');
    if (!this.userName) {
      if (this.accountService.login(loginDto)) {

        this.accountService.getUser().then((user: AuthorizedUserDto) => {
          console.log(user);
          this.userName = user.name;
        });

        this.loginModal.close();
      } else {
        this.loginModal.loginError();
      }
    } else {
      alert('Вы уже вошли в систему!');
    }

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
    if (this.userName)
      this.router.navigate(['/recipes/create']);
    else
      this.greetingModal.show();
  }

  registration(registrationInfo: RegistrationDto) {
    event.preventDefault();
    if (!this.userName) {
      let response = this.accountService.register(registrationInfo);

      if (response) {
        this.userName = registrationInfo.name;
        alert('Вы успешно зарегистрировались!');
      }

      console.log('Try to registration');
      this.registrationModal.close();
    } else {
      alert('Вы уже вошли в систему!');
    }
  }
}
