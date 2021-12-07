import { Component } from '@angular/core';

import { RecipeService } from '../../common/services/recipe.service';
import { RecipeIngredientDto } from '../../Dtos/recipe-ingredient-dto';
import { RecipeIngredientItemDto } from '../../Dtos/recipe-ingredient-item-dto';
import { AddRecipeDto } from './add-recipe-dto';
import { AddRecipeIngredientFront } from './add-recipe-ingredient-front';
import { AddRecipeStepDto } from './add-recipe-step-dto';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html'
})
export class RecipeCreateComponent {

  constructor(
    private recipeService: RecipeService,
  ) {
  }

  addRecipeDto: AddRecipeDto = {
    image: null,
    authorUsername: '',
    title: '',
    description: '',
    cookingTime: 0,
    personsCount: 0,
    ingredients: [],
    steps: [],
    tags: []
  };

  steps: string[] = [''];

  ingredients: AddRecipeIngredientFront[] = [{
    title: '',
    items: ''
  }];

  addRecipe() {
    for (let ingredient of this.ingredients) {
      var ingredientDto: RecipeIngredientDto = {
        title: '',
        items: []
      };

      ingredientDto.title = ingredient.title.trim();
      var ingredientsFront = ingredient.items.trim().split('\n');
      for (var ingrt of ingredientsFront) {
        var ingredientItems = ingrt.split('-');

        var itemDto: RecipeIngredientItemDto = {
          name: ingredientItems[0].trim(),
          value: ingredientItems[1].trim()
        }

        ingredientDto.items.push(itemDto);
      }


      this.addRecipeDto.ingredients.push(ingredientDto);
    }

    for (let [index, step] of this.steps.entries()) {
      var stepDto: AddRecipeStepDto = {
        stepNum: index + 1,
        description: step.trim()
      };

      this.addRecipeDto.steps.push(stepDto);
    }

    console.log(this.addRecipeDto);

    this.recipeService.addRecipe(this.addRecipeDto);
  }
}
