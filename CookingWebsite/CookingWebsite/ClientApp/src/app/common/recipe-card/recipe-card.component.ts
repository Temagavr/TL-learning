import { Component, EventEmitter, Input, Output } from '@angular/core';

import { RecipeCard } from './recipe-card';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.css']
})
export class RecipeCardComponent {

  @Input() recipeInfo: RecipeCard;

  @Output() onRecipeClick = new EventEmitter();

  rightPersons: string;

  ngOnInit(): void {
    if (this.recipeInfo.personsCount < 2) {
      this.rightPersons = 'персону';
    } else if (this.recipeInfo.personsCount > 1 && this.recipeInfo.personsCount < 5) {
      this.rightPersons = 'персоны';
    } else {
      this.rightPersons = 'персон';
    }
  }

  likeRecipe() {
    this.recipeInfo.isLiked = !this.recipeInfo.isLiked;
    if (this.recipeInfo.isLiked) {
      this.recipeInfo.likesCount = this.recipeInfo.likesCount + 1;
    } else {
      this.recipeInfo.likesCount = this.recipeInfo.likesCount - 1;
    }
  }

  favouriteRecipe() {
    this.recipeInfo.isFavourite = !this.recipeInfo.isFavourite;
    if (this.recipeInfo.isFavourite) {
      this.recipeInfo.favouritesCount = this.recipeInfo.favouritesCount + 1;
    } else {
      this.recipeInfo.favouritesCount = this.recipeInfo.favouritesCount - 1;
    }
  }

  ChooseRecipe() {
    this.onRecipeClick.emit(this.recipeInfo.id);
  }
}
