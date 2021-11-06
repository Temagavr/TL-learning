import { Component} from '@angular/core';

import { DayRecipe } from './../app.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  dayRecipe: DayRecipe = {
    imageUrl: '../../assets/dayRecipeExample.png',
    title: 'Тыквенный Супчик На Кокосовом Молоке',
    description: 'Если у вас осталась тыква, и вы не знаете что с ней сделать, то это решение для вас! Ароматный, согревающий суп-пюре на кокосовом молоке. Можно даже в Пост!',
    likes: 356,
    time: 35
  };
}
