import { Component, Input } from '@angular/core';

import { DayRecipe } from './../app.component';

@Component({
  selector: 'app-day-recipe',
  templateUrl: './day-recipe.component.html',
  styleUrls: ['./day-recipe.component.css']
})
export class DayRecipeComponent {

  @Input() dayRecipe: DayRecipe;

}
