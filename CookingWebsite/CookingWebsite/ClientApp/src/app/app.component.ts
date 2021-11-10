import { Component, ViewChild } from '@angular/core';
import { UserInteractionService } from './common/services/user-interaction.service';
import { LoginModalComponent } from './pages/home/modals/login-modal/login-modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  @ViewChild(LoginModalComponent, { static: false })
  private loginModal: LoginModalComponent;
  
  title = 'app';

  constructor(
    userInteractionService: UserInteractionService
  ) {
    userInteractionService.onOpenLoginModalRequest$.subscribe(() => {
      this.showLoginModal();
    })
  }

  showLoginModal() {
    this.loginModal.show();
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
}
