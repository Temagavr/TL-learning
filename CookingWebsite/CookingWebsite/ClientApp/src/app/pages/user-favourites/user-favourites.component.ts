import { Component, ViewChild } from '@angular/core';

import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { Router } from '@angular/router';
import { UserFavouritesService } from './user-favourites.sevice';

@Component({
  selector: 'app-user-favourites',
  templateUrl: './user-favourites.component.html',
  styleUrls: ['./user-favourites.component.css']
})
export class UserFavouritesComponent {

  recipes: RecipeCard[] = [];

  constructor(private router: Router, private userFavouritesService: UserFavouritesService) { }

  ngOnInit() {
    this.userFavouritesService.getUserFavourites(0, 4).then((recipeCards: RecipeCard[]) => {
      this.recipes = recipeCards;
    });
  }

  loadMoreRecipes() {
    let skip = this.recipes.length;

    this.userFavouritesService.getUserFavourites(skip, 2).then((recipeCards: RecipeCard[]) => {
      for (let recipe of recipeCards) {
        this.recipes.push(recipe);
      }
    });
  }
}
