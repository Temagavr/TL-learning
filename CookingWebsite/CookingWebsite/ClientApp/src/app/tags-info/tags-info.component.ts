import { Component } from '@angular/core';

import { Tag } from '../app.component';

@Component({
  selector: 'app-tags',
  templateUrl: './tags-info.component.html',
  styleUrls: ['./tags-info.component.css']
})
export class TagsInfoComponent {
  tagsInfo:  Tag[] = [
    { iconUrl: '../../../assets/bookIcon.png', title: 'Простые блюда', description: 'Время приготвления таких блюд не более 1 часа' },
    { iconUrl: '../../../assets/panIcon.png', title: 'Детское', description: 'Самые полезные блюда которые можно детям любого возраста' },
    { iconUrl: '../../../assets/chefIcon.png', title: 'От шеф-поваров', description: 'Требуют умения, времени и терпения, зато как в ресторане' },
    { iconUrl: '../../../assets/partyIcon.png', title: 'На Праздник', description: 'Чем удивить гостей, чтобы все были сыты за праздничным столом' }
  ]
}
