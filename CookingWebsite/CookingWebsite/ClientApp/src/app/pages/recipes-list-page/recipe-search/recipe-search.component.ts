import { Component } from '@angular/core';

@Component({
  selector: 'app-recipe-search',
  templateUrl: './recipe-search.component.html',
  styleUrls: ['./recipe-search.component.css']
})
export class RecipeSearchComponent {

  recommendsList = ['мясо', 'деликатесы', 'пироги', 'рыба', 'пост', 'пасха2021'];

}