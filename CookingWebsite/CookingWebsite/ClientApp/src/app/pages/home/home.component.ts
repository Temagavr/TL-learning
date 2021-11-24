import { Component, ViewChild} from '@angular/core';
import { UserInteractionService } from '../../common/services/user-interaction.service';

import { DayRecipeDto } from '../../Dtos/day-recipe-dto';
import { LoginModalComponent } from '../../common/modals/login-modal/login-modal.component';

import { Tag } from '../../common/tags-info/Tag';
import { HomeService } from '../../common/services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public dayRecipe: DayRecipeDto;

  constructor(
    private userInteractionService: UserInteractionService,
    private homeService: HomeService
  ) {
  }

  ngOnInit() {
    this.dayRecipe = {
      imageUrl: '../../assets/dayRecipeExamWithoutUsername.png',
      authorUsername: 'glazest',
      title: 'Тыквенный Супчик На Кокосовом Молоке',
      description: 'Если у вас осталась тыква, и вы не знаете что с ней сделать, то это решение для вас! Ароматный, согревающий суп-пюре на кокосовом молоке. Можно даже в Пост!',
      likesCount: 356,
      cookingTime: 35
    };

    this.getDayRecipe();
  }

  private getDayRecipe(): void {
    this.homeService.GetRecipeOfDay().then((recipeOfDayDto: DayRecipeDto) => {
      if (!recipeOfDayDto) {
        return;
      }

      this.dayRecipe = recipeOfDayDto;
    });
  }

  showLoginModal() {
    // Тут в showModal можно, например, отправлять какие то данные, если надо
    this.userInteractionService.showLoginModal();
  }

  showGreetingModal() {
    this.userInteractionService.showGreetingModal();
  }

  tagsInfo: Tag[] = [
    { iconUrl: '../../../assets/bookIcon.png', title: 'Простые блюда', description: 'Время приготвления таких блюд не более 1 часа' },
    { iconUrl: '../../../assets/panIcon.png', title: 'Детское', description: 'Самые полезные блюда которые можно детям любого возраста' },
    { iconUrl: '../../../assets/chefIcon.png', title: 'От шеф-поваров', description: 'Требуют умения, времени и терпения, зато как в ресторане' },
    { iconUrl: '../../../assets/partyIcon.png', title: 'На Праздник', description: 'Чем удивить гостей, чтобы все были сыты за праздничным столом' }
  ]
}
