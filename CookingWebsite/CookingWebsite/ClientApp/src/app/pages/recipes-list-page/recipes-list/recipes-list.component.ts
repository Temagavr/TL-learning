import { Component } from '@angular/core';

import { RecipeCard } from '../../../common/recipe-card/recipe-card';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})
export class RecipesListComponent {

  recipes: [RecipeCard] = [
    {
      imageUrl: '',
      title: '',
      description: '',
      tags: [''],
      favourite: 10,
      likes: 8,
      time: 35,
      personsCount: 5
    }
  ]

}
