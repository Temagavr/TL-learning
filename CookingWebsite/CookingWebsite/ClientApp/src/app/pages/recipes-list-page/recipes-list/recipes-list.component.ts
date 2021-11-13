import { Component } from '@angular/core';

import { RecipeCard } from '../../../common/recipe-card/recipe-card';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})

export class RecipesListComponent {

  recipes: RecipeCard[] = [
    {
      imageUrl: '../../../assets/recipes-list-page/recipeExpl1.png',
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
      imageUrl: '../../../../assets/recipes-list-page/recipeExpl2.png',
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
      imageUrl: '../../../../assets/recipes-list-page/recipeExpl3.png',
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
      imageUrl: '../../../../assets/recipes-list-page/recipeExpl4.png',
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

  loadMoreRecipes() {
    console.log('Try to load more recipes');
  }
}
