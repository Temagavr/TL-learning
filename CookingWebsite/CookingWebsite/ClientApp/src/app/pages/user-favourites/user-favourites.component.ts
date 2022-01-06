import { Component, ViewChild } from '@angular/core';

import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-favourites',
  templateUrl: './user-favourites.component.html',
  styleUrls: ['./user-favourites.component.css']
})
export class UserFavouritesComponent {

  recipes: RecipeCard[] = [];

  constructor() { }

  ngOnInit() {

  }
}
