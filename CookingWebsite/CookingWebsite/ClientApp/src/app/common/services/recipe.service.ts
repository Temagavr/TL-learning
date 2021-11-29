import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from './http.service';
import { RecipeDetailsDto } from "../../Dtos/recipe-details-dto";
import { RecipeCard } from "../recipe-card/recipe-card";

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

    if (!response) {
      alert(this.errorMsg);
    }

    return response;
  }
}
