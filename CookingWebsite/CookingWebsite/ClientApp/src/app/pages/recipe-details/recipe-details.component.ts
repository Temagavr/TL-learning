import { Component } from '@angular/core';

import { RecipeCard } from '../../common/recipe-card/recipe-card';
import { RecipeIngredient } from './recipe-ingredient';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html'
})
export class RecipeDetailsComponent {

  recipeCard: RecipeCard = {
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
  };

  recipeIngredients: RecipeIngredient[] = [
    {
      title: 'Для панна котты',
      ingredientsList: [
        { name: 'Сливки-20-30%', value: '500мл.' },
        { name: 'Молоко', value: '100мл.' },
        { name: 'Желатин', value: '2ч.л.' },
        { name: 'Сахар', value: '3ст.л.' },
        { name: 'Ванильный сахар', value: '2 ч.л.' },
      ]
    },
    {
      title: 'Для клубничного желе',
      ingredientsList: [
        { name: 'Сливки-20-30%', value: '500мл.' },
        { name: 'Молоко', value: '100мл.' },
        { name: 'Желатин', value: '2ч.л.' },
        { name: 'Сахар', value: '3ст.л.' },
        { name: 'Ванильный сахар', value: '2 ч.л.' },
      ]
    }
  ];

  recipeSteps = [
    'Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!).',
    'Добавим в сливки набухший в молоке желатин. Перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.',
    'Разольем охлажденные сливки по креманкам и поставим в холодильник до полного застывания. Это около 3-5 часов.',
    'Приготовим клубничное желе: Клубнику помоем, очистим от плодоножек. Добавим сахар. Взбиваем клубнику с помощью блендера в пюре.',
    'Добавим в миску с желатином 2ст.ложки холодной воды и сок лимона. Перемешаем и поставим на 30 минут для набухания. Доведем клубничное пюре до кипения. Добавим набухший желатин, перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.',
    'Сверху на застывшие сливки добавим охлажденное клубничное желе. Поставим в холодильник до полного застывания клубничного желе. Готовую панна коту подаем с фруктами.'
  ];

}
