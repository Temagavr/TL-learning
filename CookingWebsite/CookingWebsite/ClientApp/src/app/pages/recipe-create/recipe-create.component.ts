import { Component } from '@angular/core';

import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { RecipeService } from '../../common/services/recipe.service';
import { RecipeDetailsDto } from '../../Dtos/recipe-details-dto';
import { RecipeIngredientDto } from '../../Dtos/recipe-ingredient-dto';
import { RecipeIngredientItemDto } from '../../Dtos/recipe-ingredient-item-dto';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html'
})
export class RecipeCreateComponent {

  constructor(
    private recipeService: RecipeService,
  ) {
  }

  steps: string[] = [''];
  ingredients: RecipeIngredientDto[] = [{
    title: '',
    items: []
  }];

  addRecipe() {

  }
}
