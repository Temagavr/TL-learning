import { Component, EventEmitter, Input, Output } from '@angular/core';

import { RecipeCard } from '../../../common/recipe-card/recipe-card';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})

export class RecipesListComponent {

  @Input() recipes: RecipeCard[];

  @Output() onNavigateToRecipe = new EventEmitter();

  loadMoreRecipes() {
    console.log('Try to load more recipes');
  }

  navigateToRecipe(recipeId: number) {
    this.onNavigateToRecipe.emit(recipeId);
  }
}
