import { Component } from '@angular/core';

import { Tag } from '../../common/tags-info/Tag';

@Component({
  selector: 'app-recipes-list-page',
  templateUrl: './recipes-list-page.component.html',
})
export class RecipesListPageComponent {

  tagsInfo: Tag[] = [
    { iconUrl: '../../../assets/bookIcon.png', title: 'Простые блюда', description: '' },
    { iconUrl: '../../../assets/panIcon.png', title: 'Детское', description: '' },
    { iconUrl: '../../../assets/chefIcon.png', title: 'От шеф-поваров', description: '' },
    { iconUrl: '../../../assets/partyIcon.png', title: 'На Праздник', description: '' }
  ]
}
