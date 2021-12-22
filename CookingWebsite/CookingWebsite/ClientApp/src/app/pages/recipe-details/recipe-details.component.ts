import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { RecipeService } from '../../common/services/recipe.service';
import { RecipeDetailsDto } from '../../Dtos/recipe-details-dto';
import { RecipeIngredientDto } from '../../Dtos/recipe-ingredient-dto';
import { RecipeIngredientItemDto } from '../../Dtos/recipe-ingredient-item-dto';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html'
})
export class RecipeDetailsComponent {

  constructor(
    private recipeService: RecipeService,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  public recipeCard: RecipeCard;

  public isModify: boolean = false;

  public recipeIngredient: RecipeIngredientDto[];
  public recipeSteps: string[];

  ngOnInit() {
    this.getRecipeInfo(this.route.snapshot.params.id);
  }

  private getRecipeInfo(recipeId: number): void {
    this.recipeService.getRecipeDetails(recipeId).then((recipeDetailsDto: RecipeDetailsDto) => {
      if (!recipeDetailsDto) {
        return;
      }

      this.isModify = recipeDetailsDto.isModify;

      this.recipeCard = {
        id: 1,
        imageUrl: '',
        authorUsername: '',
        title: '',
        description: '',
        tags: [],
        isFavourite: false,
        isLiked: false,
        favouritesCount: 0,
        likesCount: 0,
        cookingTime: 0,
        personsCount: 0
      };

      this.recipeCard.imageUrl = recipeDetailsDto.imageUrl;
      this.recipeCard.authorUsername = recipeDetailsDto.authorUsername;
      this.recipeCard.title = recipeDetailsDto.title;
      this.recipeCard.description = recipeDetailsDto.description;
      this.recipeCard.tags = ['десерты', 'клубника', 'сливки'];
      this.recipeCard.isFavourite = false;
      this.recipeCard.isLiked = true;
      this.recipeCard.favouritesCount = 12 //recipeDetailsDto.favourite;
      this.recipeCard.likesCount = 6 //recipeDetailsDto.likes;
      this.recipeCard.cookingTime = recipeDetailsDto.cookingTime;
      this.recipeCard.personsCount = recipeDetailsDto.personsCount;

      this.recipeIngredient = [];
      for (let ingredient of recipeDetailsDto.ingredients) {
        let ingredientDto:RecipeIngredientDto = { title: "", items: [] };
        ingredientDto.title = ingredient.title;

        for (let item of ingredient.items) {
          let itemDto: RecipeIngredientItemDto = { name: "", value: "" };
          itemDto.name = item.name;
          itemDto.value = item.value;

          ingredientDto.items.push(itemDto);
        }
        this.recipeIngredient.push(ingredientDto);
      }

      this.recipeSteps = [];
      for (let step of recipeDetailsDto.steps) {
        this.recipeSteps.push(step);
      }
    });
  }

  deleteRecipe() {
    var respose = this.recipeService.deleteRecipe(this.route.snapshot.params.id);

    if (respose)
      this.router.navigate(['/recipes']);
  }

}
