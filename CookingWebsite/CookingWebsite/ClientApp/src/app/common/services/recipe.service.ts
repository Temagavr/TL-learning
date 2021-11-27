import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from './http.service';

@Injectable()
export class RecipeService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipe';

  public async GetRecipeDetails(recipeId: number) {

    const response = await this.Get(`${this.url}/recipe-details?id=${recipeId}`);

    if (!response) {
      alert(this.errorMsg);
    }

    return response;
  }

  public async GetRecipeList(skip: number, take: number, searchString: string) {

    const response = await this.Get(`${this.url}/search?skip=${skip}&take=${take}&searchString=${searchString}`);

    if (!response) {
      alert(this.errorMsg);
    }

    return response;
  }

  public async LoadMoreRecipes(skip: number, take: number, searchString: string) {
    console.log(`skip: ${skip}, take: ${take}`);

    const response = await this.Get(`${this.url}/load-more-recipes?skip=${skip}&take=${take}&searchString=${searchString}`);

    if (!response) {
      alert(this.errorMsg);
    }

    return response;
  }
}
