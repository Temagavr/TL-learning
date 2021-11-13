import { Component, Input } from '@angular/core';

import { RecipeCard } from './recipe-card';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.css']
})
export class RecipeCardComponent {

  @Input() recipeInfo: RecipeCard;

  likeRecipe() {
    this.recipeInfo.isLiked = !this.recipeInfo.isLiked;
    if (this.recipeInfo.isLiked) {
      this.recipeInfo.likes = this.recipeInfo.likes + 1;
    } else {
      this.recipeInfo.likes = this.recipeInfo.likes - 1;
    }
  }

  favouriteRecipe() {
    this.recipeInfo.isFavourite = !this.recipeInfo.isFavourite;
    if (this.recipeInfo.isFavourite) {
      this.recipeInfo.favourite = this.recipeInfo.favourite + 1;
    } else {
      this.recipeInfo.favourite = this.recipeInfo.favourite - 1;
    }
  }
}
