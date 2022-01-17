import { Component, ViewChild } from '@angular/core';
import { UserInteractionService } from '../../common/services/user-interaction.service';

import { DayRecipeDto } from './day-recipe-dto';

import { Tag } from '../../common/tags-info/Tag';
import { HomeService } from './home.service';
import { PreloaderComponent } from '../../common/preloader/preloader.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  @ViewChild(PreloaderComponent, { static: false })
  private preloader: PreloaderComponent;
  public preloaderShow = true;

  public dayRecipe: DayRecipeDto = {
    image: '',
    authorUsername: '',
    title: '',
    description: '',
    likesCount: 0,
    cookingTime: 0
  };

  constructor(
    private userInteractionService: UserInteractionService,
    private homeService: HomeService
  ) {
  }

  ngOnInit() {
    setTimeout(() => {
      this.preloader.isShow = false;
      this.preloaderShow = false;
    }, 3000);

    this.getDayRecipe();
  }

  private getDayRecipe(): void {
    this.homeService.getRecipeOfDay().then((recipeOfDayDto: DayRecipeDto) => {
      if (!recipeOfDayDto) {
        return;
      }

      this.dayRecipe = {
        image: recipeOfDayDto.image,
        authorUsername: recipeOfDayDto.authorUsername,
        title: recipeOfDayDto.title,
        description: recipeOfDayDto.description,
        likesCount: recipeOfDayDto.likesCount,
        cookingTime: recipeOfDayDto.cookingTime
      };
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
