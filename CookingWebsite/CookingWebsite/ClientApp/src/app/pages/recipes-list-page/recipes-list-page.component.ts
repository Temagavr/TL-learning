import { Component, ViewChild } from '@angular/core';

import { Tag } from '../../common/tags-info/Tag';

import { SearchInputComponent } from '../../common/search-input/search-input.component';
import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { Router } from '@angular/router';
import { RecipeSearchService } from './recipes-search.service';

@Component({
  selector: 'app-recipes-list-page',
  templateUrl: './recipes-list-page.component.html',
  styleUrls: ['./recipes-list-page.component.css']
})
export class RecipesListPageComponent {

  constructor(private router: Router, private recipeSearchService: RecipeSearchService) { }

  @ViewChild(SearchInputComponent, { static: false })
  private searchInput: SearchInputComponent;

  public preloaderShow = true;

  private searchString: string = '';

  ngOnInit() {
    this.searchRecipes(this.searchString);

    setTimeout(() => {
      this.preloaderShow = false;
    }, 3000);
  }

  insertTagValue(tagName) {
    this.searchInput.callInput(tagName);
  }

  recommendsList = ['мясо', 'деликатесы', 'пироги', 'рыба', 'пост', 'пасха2021'];

  tagsInfo: Tag[] = [
    { iconUrl: '../../../assets/bookIcon.png', title: 'Простые блюда', description: '' },
    { iconUrl: '../../../assets/panIcon.png', title: 'Детское', description: '' },
    { iconUrl: '../../../assets/chefIcon.png', title: 'От шеф-поваров', description: '' },
    { iconUrl: '../../../assets/partyIcon.png', title: 'На Праздник', description: '' }
  ];

  recipes: RecipeCard[];

  searchRecipes(searchString: string) {
    this.searchString = searchString;

    this.recipeSearchService.getRecipeList(0, 4, this.searchString).then((recipeCards: RecipeCard[]) => {
      this.recipes = recipeCards;
    });
  }

  loadMoreRecipes() {
    let skip = this.recipes.length;

    this.recipeSearchService.getRecipeList(skip, 2, this.searchString).then((recipeCards: RecipeCard[]) => {
      for (let recipe of recipeCards) {
        this.recipes.push(recipe);
      }
    });
  }
}
