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
    this.userFavouritesService.getUserFavourites().then((recipeCards: RecipeCard[]) => {
      this.recipes = recipeCards;
    });
  }
}
