import { Component, Input } from '@angular/core';

import { RecipeCard } from './recipe-card';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.css']
})
export class RecipeCardComponent {

  @Input() recipeInfo: RecipeCard;

}
