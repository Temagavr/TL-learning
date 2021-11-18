import { Component, Input } from '@angular/core';

import { RecipeIngredientsList } from '../recipe-ingredients-list';

@Component({
  selector: 'app-recipe-info-body',
  templateUrl: './recipe-info-body.component.html',
  styleUrls: ['./recipe-info-body.component.css']
})
export class RecipeInfoBodyComponent {

  @Input() recipeSteps: string[];

  @Input() recipeIngredients: RecipeIngredientsList[];

}
