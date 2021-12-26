import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../../common/services/http.service';

@Injectable()
export class RecipeLikeService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipes';

  public async likeRecipe(recipeId: number) {
    const response = await this.Post(`${this.url}/${recipeId}/likes/add`, {});

    return response;
  }

  public async unlikeRecipe(recipeId: number) {
    const response = await this.Post(`${this.url}/${recipeId}/likes/remove`, {});

    return response;
  }
}
