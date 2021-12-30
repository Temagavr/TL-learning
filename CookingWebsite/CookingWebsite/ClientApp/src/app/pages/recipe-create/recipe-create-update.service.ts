import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../../common/services/http.service';
import { RecipeDetailsDto } from "./recipe-details-dto";
import { AddRecipeDto } from "../../pages/recipe-create/add-recipe-dto";
import { UpdateRecipeDto } from "../../pages/recipe-create/update-recipe-dto";

@Injectable()
export class RecipeCreateUpdateService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipes';
 
  public async getRecipeDetails(recipeId: number): Promise<RecipeDetailsDto> {

    const response: RecipeDetailsDto = await this.Get(`${this.url}/${recipeId}/details`);

    return response;
  }
  

  public async addRecipe(addRecipeDto: AddRecipeDto): Promise<void> {
    const formData = new FormData();
    formData.append(addRecipeDto.image.name, addRecipeDto.image);

    const data: string = JSON.stringify({
      title: addRecipeDto.title,
      description: addRecipeDto.description,
      authorUsername: addRecipeDto.authorUsername,
      personsCount: addRecipeDto.personsCount,
      cookingTime: addRecipeDto.cookingTime,
      tags: addRecipeDto.tags,
      steps: addRecipeDto.steps,
      ingredients: addRecipeDto.ingredients,
    });

    formData.append('data', data);

    await this.Post(`${this.url}/create`, formData);
  }

  public async updateRecipe(updateRecipeDto: UpdateRecipeDto): Promise<void> {
    const formData = new FormData();
    if (updateRecipeDto.image)
      formData.append(updateRecipeDto.image.name, updateRecipeDto.image);

    const data: string = JSON.stringify({
      id: updateRecipeDto.id,
      title: updateRecipeDto.title,
      description: updateRecipeDto.description,
      personsCount: updateRecipeDto.personsCount,
      cookingTime: updateRecipeDto.cookingTime,
      tags: updateRecipeDto.tags,
      steps: updateRecipeDto.steps,
      ingredients: updateRecipeDto.ingredients
    });

    formData.append('data', data);

    await this.Post(`${this.url}/${updateRecipeDto.id}/update`, formData);
  }
}
