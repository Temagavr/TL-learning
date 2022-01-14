import { Component } from '@angular/core';
import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { UserMetricDto } from './user-metric-dto';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent {

  constructor(
  ) {
  }

  userRecipes: RecipeCard[];

  userStatistic: UserMetricDto[] = [
    { title: 'Всего рецептов', value: 0 },
    { title: 'Всего лайков', value: 0 },
    { title: 'В избранных', value: 0 }
  ]

  ngOnInit() {
    this.userRecipes = [];
  }
}
