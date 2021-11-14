import { Component, ViewChild } from '@angular/core';
import { UserInteractionService } from './common/services/user-interaction.service';
import { LoginModalComponent } from './common/modals/login-modal/login-modal.component';
import { RegistrationModalComponent } from './common/modals/registration-modal/registration-modal.component';
import { GreetingModalComponent } from './common/modals/greeting-modal/greeting-modal.component';

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

  userName = 'Татьяна';

  constructor(
    userInteractionService: UserInteractionService
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

  UserLogOut() {
    console.log('User log out');
  }

  doSmthOnCloseLoginModal() {
    // Тут в closeModal можно что то делать
    console.log('login modal closed');
  }

  doSmthOnLoginClick() {
    // Можно добавить в Login модал третий эмиттер(или избавиться от лишних)
    // Тут два варианта. Логиниться здесь или внутри модалки
    console.log('Im try to login');
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

  doSmthOnRegistrationClick() {
    console.log('Try to registration');
  }
}
