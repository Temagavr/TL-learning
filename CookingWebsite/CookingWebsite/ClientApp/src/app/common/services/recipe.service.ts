import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from './http.service';
import { RecipeDetailsDto } from "../../Dtos/recipe-details-dto";
import { RecipeCard } from "../recipe-card/recipe-card";
import { AddRecipeDto } from "../../pages/recipe-create/add-recipe-dto";

@Injectable()
export class RecipeService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipe';

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
      recipeIngredient: addRecipeDto.recipeIngredient
    });

    formData.append('data', data);

    const response = await this.Post(`${this.url}/add-recipe`, formData);

    return response;
  }
}
