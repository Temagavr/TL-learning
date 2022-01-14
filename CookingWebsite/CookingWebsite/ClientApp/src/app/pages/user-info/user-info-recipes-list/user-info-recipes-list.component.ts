import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RecipeCard } from '../../../common/recipe-card/recipe-card';

@Component({
  selector: 'app-user-info-recipes-list',
  templateUrl: './user-info-recipes-list.component.html',
  styleUrls: ['./user-info-recipes-list.component.css']
})
export class UserInfoRecipesListComponent {

  @Input() recipes: RecipeCard[];

  @Output() loadMoreClick = new EventEmitter();

  constructor(
  ) {

  }

  loadMoreRecipes() {
    this.loadMoreClick.emit();
  }
}
