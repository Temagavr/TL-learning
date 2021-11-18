import { Component, Input } from '@angular/core';

import { RecipeIngredient } from '../recipe-ingredient';

@Component({
  selector: 'app-recipe-info-body',
  templateUrl: './recipe-info-body.component.html',
  styleUrls: ['./recipe-info-body.component.css']
})
export class RecipeInfoBodyComponent {

  @Input() recipeSteps: string[];

  @Input() recipeIngredients: RecipeIngredient[];

}
