import { Component } from '@angular/core';
import { RecipeCard } from '../../common/recipe-card/recipe-card';

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

  ngOnInit() {
  }
}
