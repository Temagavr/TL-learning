import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../../common/services/http.service';
import { RecipeCard } from "../../common/recipe-card/recipe-card";

@Injectable()
export class RecipeSearchService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/recipes';

  public async getRecipeList(skip: number, take: number, searchString: string): Promise<RecipeCard[]> {

    const response: RecipeCard[] = await this.Get(`${this.url}/search?skip=${skip}&take=${take}&searchString=${searchString}`);

    return response;
  }
}
