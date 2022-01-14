import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../../common/services/http.service';

@Injectable()
export class RecipeFavouriteService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipes';

  public async favouriteRecipe(recipeId: number): Promise<void> {
    await this.Post(`${this.url}/${recipeId}/favourites/add`, {});
  }

  public async unfavouriteRecipe(recipeId: number): Promise<void> {
    await this.Post(`${this.url}/${recipeId}/favourites/remove`, {});
  }
}

