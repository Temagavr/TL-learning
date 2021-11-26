import { Component, ViewChild } from '@angular/core';

import { Tag } from '../../common/tags-info/Tag';

import { SearchInputComponent } from '../../common/search-input/search-input.component';
import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { Router } from '@angular/router';
import { RecipeService } from '../../common/services/recipe.service';

@Component({
  selector: 'app-recipes-list-page',
  templateUrl: './recipes-list-page.component.html',
  styleUrls: ['./recipes-list-page.component.css']
})
export class RecipesListPageComponent {

  constructor(private router: Router, private recipeService: RecipeService) { }

  @ViewChild(SearchInputComponent, { static: false })
  private searchInput: SearchInputComponent;

  private skip: number = 4;
  private take: number = 2;

  ngOnInit() {
    this.InitData();
    this.searchRecipes('');
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

  redirectToRecipe(recipeId: number) {
    this.router.navigate(['/recipes', recipeId]);
  }

  InitData() {
    this.recipes =[
      {
        id: 2,
        imageUrl: '../../../assets/recipes/recipeExpl1WithoutUsername.png',
        authorUsername: 'glazest',
        title: 'Клубничная панна-котта',
        description: 'Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах, украсив взбитыми сливками, свежими ягодами и мятой.',
        tags: ['десерты', 'клубника', 'сливки'],
        isFavourite: true,
        isLiked: false,
        favouritesCount: 10,
        likesCount: 8,
        cookingTime: 35,
        personsCount: 5
      },
      {
        id: 3,
        imageUrl: '../../../../assets/recipes-list-page/recipeExpl2WithoutUsername.png',
        authorUsername: 'horilka',
        title: 'Мясные фрикадельки',
        description: 'Мясные фрикадельки в томатном соусе - несложное и вкусное блюдо, которым можно порадовать своих близких.',
        tags: ['вторые блюда', 'мясо', 'соевый соус'],
        isFavourite: false,
        isLiked: false,
        favouritesCount: 4,
        likesCount: 7,
        cookingTime: 90,
        personsCount: 4
      },
      {
        id: 4,
        imageUrl: '../../../../assets/recipes-list-page/recipeExpl3WithoutUsername.png',
        authorUsername: 'turum-pum-pum',
        title: 'Панкейки',
        description: 'Панкейки: меньше, чем блины, но больше, чем оладьи. Основное отличие — в тесте, оно должно быть воздушным, чтобы панкейки не растекались по сковородке...',
        tags: ['десерты', 'завтрак', 'блины'],
        isFavourite: true,
        isLiked: true,
        favouritesCount: 25,
        likesCount: 7,
        cookingTime: 40,
        personsCount: 3
      },
      {
        id: 5,
        imageUrl: '../../../../assets/recipes-list-page/recipeExpl4WithoutUsername.png',
        authorUsername: 'sweet-girl',
        title: 'Полезное мороженое без сахара',
        description: 'Йогуртовое мороженое сочетает в себе нежный вкус и низкую калорийность, что будет особенно актуально для сладкоежек, соблюдающих диету.',
        tags: ['десерты', 'вишня', 'мороженное'],
        isFavourite: false,
        isLiked: false,
        favouritesCount: 7,
        likesCount: 4,
        cookingTime: 35,
        personsCount: 2
      },
    ];
  }

  searchRecipes(searchString: string) {
    this.take = 4;
    this.skip = 0;

    this.recipeService.GetRecipeList(searchString).then((recipeCards: RecipeCard[]) => {
      this.recipes = recipeCards;
    });

    this.skip = this.take;
    this.take = 2;
  }

  loadMoreRecipes(searchString: string) {
    this.recipeService.LoadMoreRecipes(this.skip, this.take, searchString).then((recipeCards: RecipeCard[]) => {
      console.log(recipeCards);
      this.skip += this.take;
      for (let recipe in recipeCards) {
        console.log(recipe);
        //this.recipes.push(recipe);
      }
    });
  }
}
