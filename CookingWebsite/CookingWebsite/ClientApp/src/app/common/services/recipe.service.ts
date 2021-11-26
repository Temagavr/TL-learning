import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from './http.service';
import { LoadMoreRecipesDto } from '../../Dtos/load-more-recipes-dto';

@Injectable()
export class RecipeService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipe';

  public async GetRecipeDetails(recipeId: number) {

    const response = await this.Post(`${this.url}/recipeDetails/${recipeId}`, {});

    if (!response) {
      alert(this.errorMsg);
    }

    return response;
  }

  public async GetRecipeList(searchString: string) {

    const response = await this.Post(`${this.url}/searchRecipes`, { searchString });

    if (!response) {
      alert(this.errorMsg);
    }

    return response;
  }

  public async LoadMoreRecipes(skip: number, take: number, searchString: string) {
    var loadMore: LoadMoreRecipesDto = { skip: skip, take: take, searchString: searchString };
    console.log(`skip: ${loadMore.skip}, take: ${loadMore.take}`);

    const response = await this.Post(`${this.url}/loadMoreRecipes`, loadMore);

    if (!response) {
      alert(this.errorMsg);
    }

    return response;
  }
}
