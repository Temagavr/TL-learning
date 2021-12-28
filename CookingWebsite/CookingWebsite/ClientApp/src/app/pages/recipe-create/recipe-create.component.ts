import { Component } from '@angular/core';
import { AccountService } from '../../common/account/account.service';

import { RecipeCreateUpdateService } from './recipe-create-update.service';
import { AuthorizedUserDto } from '../../common/account/authorized-user-dto';
import { RecipeIngredientDto } from './recipe-ingredient-dto';
import { RecipeIngredientItemDto } from './recipe-ingredient-item-dto';
import { AddRecipeDto } from './add-recipe-dto';
import { AddRecipeIngredientFront } from './add-recipe-ingredient-front';
import { AddRecipeStepDto } from './add-recipe-step-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html'
})
export class RecipeCreateComponent {

  constructor(
    private recipeCUService: RecipeCreateUpdateService,
    private router: Router,
    private accountService: AccountService
  ) {
  }

  addRecipeDto: AddRecipeDto = {
    image: null,
    imageUrl: '',
    authorUsername: '',
    title: '',
    description: '',
    cookingTime: 0,
    personsCount: 0,
    ingredients: [],
    steps: [],
    tags: [],
    tagsString: ''
  };

  steps: string[] = [''];

  ingredients: AddRecipeIngredientFront[] = [{
    title: '',
    items: ''
  }];

  async addRecipe() {
    this.addRecipeDto.ingredients = this.ingredients.map(function (ingredient): RecipeIngredientDto {
      let ingredientDto: RecipeIngredientDto = {
        title: '',
        items: []
      };

      ingredientDto.title = ingredient.title.trim();
      let ingredientsFront: string[] = ingredient.items.trim().split('\n');

      ingredientDto.items = ingredientsFront.map(function (item: string): RecipeIngredientItemDto {
        let ingredientItems: string[] = item.split('-');

        let itemDto: RecipeIngredientItemDto = {
          name: ingredientItems[0].trim(),
          value: ingredientItems[1].trim()
        }

        return itemDto;
      })

      return ingredientDto;
    })

    for (let [index, step] of this.steps.entries()) {
      let stepDto: AddRecipeStepDto = {
        stepNumber: index + 1,
        description: step.trim()
      };

      this.addRecipeDto.steps.push(stepDto);
    }

	this.accountService.getUser().then((user: AuthorizedUserDto) => {
      if (user.id != 0) {
        this.addRecipeDto.authorUsername = user.login;
      }
    });

	if (this.addRecipeDto.tagsString != '') {

      let tags: string[] = this.addRecipeDto.tagsString.split(',');

      for (let tag of tags) {
        this.addRecipeDto.tags.push(tag.trim().toLowerCase());
      }

    }    console.log(this.addRecipeDto);

    await this.recipeCUService.addRecipe(this.addRecipeDto);

    this.router.navigate(["/recipes"]);
  }
}
