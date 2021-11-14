import { Component, Input } from '@angular/core';

import { Tag } from '../Tag';

@Component({
  selector: 'app-tags-list',
  templateUrl: './tags-list.component.html',
  styleUrls: ['./tags-list.component.css']
})
export class TagsListComponent {
  @Input() tagsList: Tag[];
}
