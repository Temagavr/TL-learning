import { Component, Input } from '@angular/core';

import { RecipeIngredient } from '../recipe-ingredient';

@Component({
  selector: 'app-recipe-details-body',
  templateUrl: './recipe-details-body.component.html',
  styleUrls: ['./recipe-details-body.component.css']
})
export class RecipeDetailsBodyComponent {

  @Input() recipeSteps: string[];

  @Input() recipeIngredients: RecipeIngredient[];

}
