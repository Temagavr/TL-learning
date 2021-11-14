import { Component, Input } from '@angular/core';

import { Tag } from './Tag';

@Component({
  selector: 'app-tags-info',
  templateUrl: './tags-info.component.html',
  styleUrls: ['./tags-info.component.css']
})
export class TagsInfoComponent {
  @Input() tagsList: Tag[];
}
