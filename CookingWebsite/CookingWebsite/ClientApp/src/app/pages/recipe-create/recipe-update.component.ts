import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { RecipeCreateUpdateService } from './recipe-create-update.service';
import { RecipeDetailsDto } from './recipe-details-dto';
import { RecipeIngredientDto } from './recipe-ingredient-dto';
import { RecipeIngredientItemDto } from './recipe-ingredient-item-dto';
import { AddRecipeDto } from './add-recipe-dto';
import { AddRecipeIngredientFront } from './add-recipe-ingredient-front';
import { AddRecipeStepDto } from './add-recipe-step-dto';
import { UpdateRecipeDto } from './update-recipe-dto';

@Component({
  selector: 'app-recipe-update',
  templateUrl: './recipe-update.component.html'
})
export class RecipeUpdateComponent {

  constructor(
    private recipeCUService: RecipeCreateUpdateService,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  private baseImageUrl: string  = '../../../assets/';

  recipeData: AddRecipeDto;

  public recipeIngredient: AddRecipeIngredientFront[];
  public recipeSteps: string[];

  ngOnInit() {
    this.getRecipeInfo(this.route.snapshot.params.id);
  }

  private async getRecipeInfo(recipeId: number) {
    await this.recipeCUService.getRecipeDetails(recipeId).then((recipeDetailsDto: RecipeDetailsDto) => {
      if (!recipeDetailsDto) {
        return;
      }

      this.recipeData = {
        image: null,
        imageUrl: '',
        authorUsername: '',
        title: '',
        description: '',
        tags: [],
        cookingTime: 0,
        personsCount: 0,
        ingredients: [],
        steps: [],
        tagsString: ''
      };

      this.recipeData.imageUrl = this.baseImageUrl + recipeDetailsDto.imageUrl;
      this.recipeData.authorUsername = recipeDetailsDto.authorUsername;
      this.recipeData.title = recipeDetailsDto.title;
      this.recipeData.description = recipeDetailsDto.description;
      this.recipeData.tags = recipeDetailsDto.tags;
      this.recipeData.tagsString = this.recipeData.tags.join(', ');
      this.recipeData.cookingTime = recipeDetailsDto.cookingTime;
      this.recipeData.personsCount = recipeDetailsDto.personsCount;

      this.recipeIngredient = [];
      for (let ingredient of recipeDetailsDto.ingredients) {
        let ingredientDto: AddRecipeIngredientFront = { title: "", items: '' };
        ingredientDto.title = ingredient.title;

        for (let item of ingredient.items) {
          ingredientDto.items += `${item.name} - ${item.value}\n`;
        }
        this.recipeIngredient.push(ingredientDto);
      }

      this.recipeSteps = [];
      for (let step of recipeDetailsDto.steps) {
        this.recipeSteps.push(step);
      }
    });
  }

  async updateRecipe() {
    let updatedRecipe: UpdateRecipeDto = {
      id: this.route.snapshot.params.id,
      image: this.recipeData.image,
      title: this.recipeData.title,
      description: this.recipeData.description,
      cookingTime: this.recipeData.cookingTime,
      personsCount: this.recipeData.personsCount,
      ingredients: [],
      steps: [],
      tags: []
    };

    updatedRecipe.ingredients = this.recipeIngredient.map(function (ingredient): RecipeIngredientDto {
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
    });

    for (let [index, step] of this.recipeSteps.entries()) {
      let stepDto: AddRecipeStepDto = {
        stepNumber: index + 1,
        description: step.trim()
      };

      updatedRecipe.steps.push(stepDto);
    }

    if (this.recipeData.tagsString != '') {
      let tags: string[] = this.recipeData.tagsString.split(',');

      for (let tag of tags) {
        updatedRecipe.tags.push(tag.trim().toLowerCase());
      }
    }

    let response = await this.recipeCUService.updateRecipe(updatedRecipe);

    this.router.navigate(['/recipes/details', updatedRecipe.id]);
  }
}
