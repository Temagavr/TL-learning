import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../../common/services/http.service';
import { RecipeCard } from "../../common/recipe-card/recipe-card";
import { UserInfoDto } from "./user-info-dto";


@Injectable()
export class UserInfoService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/user';

  public async getUserInfo(): Promise<UserInfoDto> {

    const response: UserInfoDto = await this.Get(`${this.url}/info`);

    return response;
  }

  public async getUserRecipes(skip: number, take: number): Promise<RecipeCard[]> {

    const response: RecipeCard[] = await this.Get(`${this.url}/recipes?skip=${skip}&take=${take}`);

    return response;
  }
}
