import { Component, Input } from '@angular/core';

import { DayRecipeDto } from '../day-recipe-dto';

@Component({
  selector: 'app-day-recipe',
  templateUrl: './day-recipe.component.html',
  styleUrls: ['./day-recipe.component.css']
})
export class DayRecipeComponent {
  @Input() dayRecipe: DayRecipeDto;
}
