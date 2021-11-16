import { Component, ViewChild } from '@angular/core';

import { Tag } from '../../common/tags-info/Tag';

import { SearchInputComponent } from '../../common/search-input/search-input.component';

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
  ]
}
