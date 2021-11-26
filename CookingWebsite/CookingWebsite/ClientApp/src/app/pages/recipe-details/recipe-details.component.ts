import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { RecipeService } from '../../common/services/recipe.service';
import { RecipeDetailsDto } from '../../Dtos/recipe-details-dto';
import { RecipeIngredientDto } from '../../Dtos/recipe-ingredient-dto';
import { RecipeIngredientItemDto } from '../../Dtos/recipe-ingredient-item-dto';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html'
})
export class RecipeDetailsComponent {

  constructor(
    private recipeService: RecipeService,
    private route: ActivatedRoute
  ) {
  }

  public recipeCard: RecipeCard;
  public recipeIngredient: RecipeIngredientDto[];
  public recipeSteps: string[];

  ngOnInit() {
    this.InitData();
    this.GetRecipeInfo(this.route.snapshot.params.id);
  }

  private InitData() {
    this.recipeCard = {
      id: 2,
      imageUrl: '../../../assets/recipes-list-page/recipeExpl1WithoutUsername.png',
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
    };

    this.recipeIngredient = [
      {
        title: 'Для панна котты',
        items: [
          { name: 'Сливки-20-30%', value: '500мл.' },
          { name: 'Молоко', value: '100мл.' },
          { name: 'Желатин', value: '2ч.л.' },
          { name: 'Сахар', value: '3ст.л.' },
          { name: 'Ванильный сахар', value: '2 ч.л.' },
        ]
      },
      {
        title: 'Для клубничного желе',
        items: [
          { name: 'Сливки-20-30%', value: '500мл.' },
          { name: 'Молоко', value: '100мл.' },
          { name: 'Желатин', value: '2ч.л.' },
          { name: 'Сахар', value: '3ст.л.' },
          { name: 'Ванильный сахар', value: '2 ч.л.' },
        ]
      }
    ];

    this.recipeSteps = [
      'Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!).',
      'Добавим в сливки набухший в молоке желатин. Перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.',
      'Разольем охлажденные сливки по креманкам и поставим в холодильник до полного застывания. Это около 3-5 часов.',
      'Приготовим клубничное желе: Клубнику помоем, очистим от плодоножек. Добавим сахар. Взбиваем клубнику с помощью блендера в пюре.',
      'Добавим в миску с желатином 2ст.ложки холодной воды и сок лимона. Перемешаем и поставим на 30 минут для набухания. Доведем клубничное пюре до кипения. Добавим набухший желатин, перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.',
      'Сверху на застывшие сливки добавим охлажденное клубничное желе. Поставим в холодильник до полного застывания клубничного желе. Готовую панна коту подаем с фруктами.'
    ];
  }

  private GetRecipeInfo(recipeId: number): void {
    this.recipeService.GetRecipeDetails(recipeId).then((recipeDetailsDto: RecipeDetailsDto) => {
      if (!recipeDetailsDto) {
        return;
      }

      this.recipeCard.imageUrl = recipeDetailsDto.imageUrl;
      this.recipeCard.authorUsername = recipeDetailsDto.authorUsername;
      this.recipeCard.title = recipeDetailsDto.title;
      this.recipeCard.description = recipeDetailsDto.description;
      this.recipeCard.tags = ['десерты', 'клубника', 'сливки'],
      this.recipeCard.isFavourite = false,
      this.recipeCard.isLiked = true;;
      this.recipeCard.favouritesCount = 12 //recipeDetailsDto.favourite;
      this.recipeCard.likesCount = 6 //recipeDetailsDto.likes;
      this.recipeCard.cookingTime = recipeDetailsDto.cookingTime;
      this.recipeCard.personsCount = recipeDetailsDto.personsCount;

      this.recipeIngredient = [];
      for (let ingredient of recipeDetailsDto.ingredient) {
        var ingredientDto:RecipeIngredientDto = { title: "", items: [] };
        ingredientDto.title = ingredient.title;

        for (let item of ingredient.items) {
          var itemDto: RecipeIngredientItemDto = { name: "", value: "" };
          itemDto.name = item.name;
          itemDto.value = item.value;

          ingredientDto.items.push(itemDto);
        }
        this.recipeIngredient.push(ingredientDto);
      }

      this.recipeSteps = [];
      for (let step of recipeDetailsDto.steps) {
        this.recipeSteps.push(step);
      }
    });
  }

}
