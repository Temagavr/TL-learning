import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from './http.service';
import { DayRecipeDto } from '../../Dtos/day-recipe-dto';

@Injectable()
export class HomeService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/home';

  public async GetRecipeOfDay(){

    console.log('Try to get recipe of day');

    const response: DayRecipeDto = await this.Get(`${this.url}/recipeOfDay`);

    if (!response) {
      alert(this.errorMsg);
    }

    return response;
  }
}
