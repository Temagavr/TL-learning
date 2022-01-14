import { Component } from '@angular/core';
import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { UserMetricDto } from './user-metric-dto';

import { UserInfoService } from './user-info.service';
import { UserInfoDto } from './user-info-dto';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent {

  constructor( private userInfoService: UserInfoService) {
  }

  userInfo: UserInfoDto = {
    login: "",
    name: "",
    description: "",
    favouritesCount: 0,
    likesCount: 0,
    recipesCount: 0
  };

  userRecipes: RecipeCard[];

  userStatistic: UserMetricDto[] = [
    { title: 'Всего рецептов', value: 0 },
    { title: 'Всего лайков', value: 0 },
    { title: 'В избранных', value: 0 }
  ]

  ngOnInit() {
    this.getUserInfo();

    this.userRecipes = [];
  }

  private getUserInfo(): void {
    this.userInfoService.getUserInfo().then((userInfoDto: UserInfoDto) => {
      console.log(userInfoDto);

      this.userInfo.login = userInfoDto.login;
      this.userInfo.name = userInfoDto.name;
      this.userInfo.description = userInfoDto.description;

      this.userStatistic[0].value = userInfoDto.recipesCount;
      this.userStatistic[1].value = userInfoDto.likesCount;
      this.userStatistic[2].value = userInfoDto.favouritesCount;
    });
  }
}
