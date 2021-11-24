import { Component, ViewChild } from '@angular/core';

import { Tag } from '../../common/tags-info/Tag';

import { SearchInputComponent } from '../../common/search-input/search-input.component';
import { RecipeCard } from '../../common/recipe-card/recipe-card';

@Component({
  selector: 'app-recipes-list-page',
  templateUrl: './recipes-list-page.component.html',
  styleUrls: ['./recipes-list-page.component.css']
})
export class RecipesListPageComponent {
  @ViewChild(SearchInputComponent, { static: false })
  private searchInput: SearchInputComponent;

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

  recipes: RecipeCard[] = [
    {
      imageUrl: '../../../assets/recipes-list-page/recipeExpl1WithoutUsername.png',
      authorUsername: 'glazest',
      title: 'Клубничная панна-котта',
      description: 'Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах, украсив взбитыми сливками, свежими ягодами и мятой.',
      tags: ['десерты', 'клубника', 'сливки'],
      isFavourite: true,
      isLiked: false,
      favourite: 10,
      likes: 8,
      time: 35,
      personsCount: 5
    },
    {
      imageUrl: '../../../../assets/recipes-list-page/recipeExpl2WithoutUsername.png',
      authorUsername: 'horilka',
      title: 'Мясные фрикадельки',
      description: 'Мясные фрикадельки в томатном соусе - несложное и вкусное блюдо, которым можно порадовать своих близких.',
      tags: ['вторые блюда', 'мясо', 'соевый соус'],
      isFavourite: false,
      isLiked: false,
      favourite: 4,
      likes: 7,
      time: 90,
      personsCount: 4
    },
    {
      imageUrl: '../../../../assets/recipes-list-page/recipeExpl3WithoutUsername.png',
      authorUsername: 'turum-pum-pum',
      title: 'Панкейки',
      description: 'Панкейки: меньше, чем блины, но больше, чем оладьи. Основное отличие — в тесте, оно должно быть воздушным, чтобы панкейки не растекались по сковородке...',
      tags: ['десерты', 'завтрак', 'блины'],
      isFavourite: true,
      isLiked: true,
      favourite: 25,
      likes: 7,
      time: 40,
      personsCount: 3
    },
    {
      imageUrl: '../../../../assets/recipes-list-page/recipeExpl4WithoutUsername.png',
      authorUsername: 'sweet-girl',
      title: 'Полезное мороженое без сахара',
      description: 'Йогуртовое мороженое сочетает в себе нежный вкус и низкую калорийность, что будет особенно актуально для сладкоежек, соблюдающих диету.',
      tags: ['десерты', 'вишня', 'мороженное'],
      isFavourite: false,
      isLiked: false,
      favourite: 7,
      likes: 4,
      time: 35,
      personsCount: 2
    },
  ]
}
