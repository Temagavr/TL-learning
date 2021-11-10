import { Component, ViewChild} from '@angular/core';
import { UserInteractionService } from 'src/app/common/services/user-interaction.service';

import { DayRecipe } from './day-recipe';
import { LoginModalComponent } from './modals/login-modal/login-modal.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  isGreetingModal = false;

  isRegistrationModal = false;

  constructor(
    private userInteractionService: UserInteractionService
  ) {
  }

  toggleRegistrationModal() {
    this.isRegistrationModal = !this.isRegistrationModal;
  }

  showLoginModal() {
    // Тут в showModal можно, например, отправлять какие то данные, если надо
    this.userInteractionService.showLoginModal();
  }

  toggleGreetingModal() {
    this.isGreetingModal = !this.isGreetingModal;
  }

  switchToRegistration() {
    // this.showLoginModal();
    // this.toggleRegistrationModal();
  }

  switchToLogin() {
    this.toggleRegistrationModal();
    // this.toggleLoginModal();
  }

  switchToLoginFrGreeting() {
    this.toggleGreetingModal();
    // this.toggleLoginModal();
  }

  switchToRegistrationFrGreeting() {
    this.toggleGreetingModal();
    this.toggleRegistrationModal();
  }

  dayRecipe: DayRecipe = {
    imageUrl: '../../assets/dayRecipeExample.png',
    title: 'Тыквенный Супчик На Кокосовом Молоке',
    description: 'Если у вас осталась тыква, и вы не знаете что с ней сделать, то это решение для вас! Ароматный, согревающий суп-пюре на кокосовом молоке. Можно даже в Пост!',
    likes: 356,
    time: 35
  };
}
