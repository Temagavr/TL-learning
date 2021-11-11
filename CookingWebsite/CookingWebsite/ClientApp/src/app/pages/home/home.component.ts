import { Component, ViewChild} from '@angular/core';
import { UserInteractionService } from '../../common/services/user-interaction.service';

import { DayRecipe } from './day-recipe';
import { LoginModalComponent } from '../../common/modals/login-modal/login-modal.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  
  constructor(
    private userInteractionService: UserInteractionService
  ) {
  }

  showLoginModal() {
    // Тут в showModal можно, например, отправлять какие то данные, если надо
    this.userInteractionService.showLoginModal();
  }

  showGreetingModal() {
    this.userInteractionService.showGreetingModal();
  }

  dayRecipe: DayRecipe = {
    imageUrl: '../../assets/dayRecipeExample.png',
    title: 'Тыквенный Супчик На Кокосовом Молоке',
    description: 'Если у вас осталась тыква, и вы не знаете что с ней сделать, то это решение для вас! Ароматный, согревающий суп-пюре на кокосовом молоке. Можно даже в Пост!',
    likes: 356,
    time: 35
  };
}
