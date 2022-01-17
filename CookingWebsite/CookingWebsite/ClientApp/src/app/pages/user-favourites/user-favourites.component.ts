import { Component, ViewChild } from '@angular/core';

import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { Router } from '@angular/router';
import { UserFavouritesService } from './user-favourites.sevice';
import { PreloaderComponent } from '../../common/preloader/preloader.component';

@Component({
  selector: 'app-user-favourites',
  templateUrl: './user-favourites.component.html',
  styleUrls: ['./user-favourites.component.css']
})
export class UserFavouritesComponent {

  recipes: RecipeCard[] = [];

  constructor(private router: Router, private userFavouritesService: UserFavouritesService) { }

  @ViewChild(PreloaderComponent, { static: false })
  private preloader: PreloaderComponent;
  public preloaderShow = true;


  ngOnInit() {
    this.userFavouritesService.getUserFavourites(0, 4).then((recipeCards: RecipeCard[]) => {
      this.recipes = recipeCards;
    });

    setTimeout(() => {
      this.preloader.isShow = false;
      this.preloaderShow = false;
    }, 3000);
  }

  loadMoreRecipes() {
    let skip = this.recipes.length;
    const take = 2;

    this.userFavouritesService.getUserFavourites(skip, take).then((recipeCards: RecipeCard[]) => {
      for (let recipe of recipeCards) {
        this.recipes.push(recipe);
      }
    });
  }
}
