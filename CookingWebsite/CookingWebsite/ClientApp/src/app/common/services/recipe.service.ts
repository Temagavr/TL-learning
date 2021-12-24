import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from './http.service';
import { RecipeDetailsDto } from "../../Dtos/recipe-details-dto";
import { RecipeCard } from "../recipe-card/recipe-card";
import { AddRecipeDto } from "../../pages/recipe-create/add-recipe-dto";
import { UpdateRecipeDto } from "../../pages/recipe-create/update-recipe-dto";

@Injectable()
export class RecipeService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipes';

  public async getRecipeDetails(recipeId: number) {

    const response: RecipeDetailsDto = await this.Get(`${this.url}/${recipeId}/details`);

    return response;
  }

  public async getRecipeList(skip: number, take: number, searchString: string) {

    const response: RecipeCard[] = await this.Get(`${this.url}/search?skip=${skip}&take=${take}&searchString=${searchString}`);

    return response;
  }

  public async addRecipe(addRecipeDto: AddRecipeDto) {
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
      ingredients: addRecipeDto.ingredients
    });

    formData.append('data', data);

    const response = await this.Post(`${this.url}/create`, formData);

    return response;
  }

  public async updateRecipe(updateRecipeDto: UpdateRecipeDto) {
    const formData = new FormData();
    if(updateRecipeDto.image)
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

    const response = await this.Post(`${this.url}/update-recipe`, formData);

    return response;
  }

  public async deleteRecipe(recipeId: number) {

    const response = await this.Post(`${this.url}/${recipeId}/delete`, {});

    return response;
  }
}
