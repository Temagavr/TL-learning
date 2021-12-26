import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../../common/services/http.service';
import { RecipeDetailsDto } from "./recipe-details-dto";

@Injectable()
export class RecipeDetailsService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipes';

  public async getRecipeDetails(recipeId: number): Promise<RecipeDetailsDto> {

    const response: RecipeDetailsDto = await this.Get(`${this.url}/${recipeId}/details`);

    return response;
  }

  public async deleteRecipe(recipeId: number) {

    const response = await this.Post(`${this.url}/${recipeId}/delete`, {});

    return response;
  }
}
