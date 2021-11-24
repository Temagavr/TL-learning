import { Component, Input } from '@angular/core';

import { RecipeCard } from '../../../common/recipe-card/recipe-card';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})

export class RecipesListComponent {

  @Input() recipes: RecipeCard[];

  loadMoreRecipes() {
    console.log('Try to load more recipes');
  }
}
