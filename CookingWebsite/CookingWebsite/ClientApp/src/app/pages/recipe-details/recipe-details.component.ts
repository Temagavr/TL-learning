import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { RecipeDetailsService } from './recipe-details.service';
import { RecipeDetailsDto } from './recipe-details-dto';
import { RecipeIngredientDto } from './recipe-ingredient-dto';
import { RecipeIngredientItemDto } from './recipe-ingredient-item-dto';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html'
})
export class RecipeDetailsComponent {

  constructor(
    private recipeDetailsService: RecipeDetailsService,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  public recipeCard: RecipeCard;

  public isCanModify: boolean = false;

  public recipeIngredient: RecipeIngredientDto[];
  public recipeSteps: string[];

  ngOnInit() {
    this.getRecipeInfo(this.route.snapshot.params.id);
  }

  private getRecipeInfo(recipeId: number): void {
    this.recipeDetailsService.getRecipeDetails(recipeId).then((recipeDetailsDto: RecipeDetailsDto) => {
      if (!recipeDetailsDto) {
        return;
      }

      this.isCanModify = recipeDetailsDto.isCanModify;

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

      if(recipeDetailsDto.tags.length > 0)
        this.recipeCard.tags = recipeDetailsDto.tags.slice(0, 3);
      
      this.recipeCard.isFavourite = false;
      this.recipeCard.isLiked = recipeDetailsDto.isLiked;
      this.recipeCard.favouritesCount = 12 //recipeDetailsDto.favourite;
      this.recipeCard.likesCount = recipeDetailsDto.likesCount;
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

  public async deleteRecipe(){
    let respose = await this.recipeDetailsService.deleteRecipe(this.route.snapshot.params.id);

    if (respose != null)
      this.router.navigate(['/recipes']);
  }
}
