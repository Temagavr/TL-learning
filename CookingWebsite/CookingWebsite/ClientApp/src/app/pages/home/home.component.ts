import { Component} from '@angular/core';

import { DayRecipe } from './day-recipe';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  isLoginModal = false;

  isGreetingModal = false;

  isRegistrationModal = false;

  toggleRegistrationModal() {
    this.isRegistrationModal = !this.isRegistrationModal;
  }

  toggleLoginModal() {
    this.isLoginModal = !this.isLoginModal;
  }

  toggleGreetingModal() {
    this.isGreetingModal = !this.isGreetingModal;
  }

  switchToRegistration() {
    this.toggleLoginModal();
    this.toggleRegistrationModal();
  }

  switchToLogin() {
    this.toggleRegistrationModal();
    this.toggleLoginModal();
  }

  switchToLoginFrGreeting() {
    this.toggleGreetingModal();
    this.toggleLoginModal();
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
