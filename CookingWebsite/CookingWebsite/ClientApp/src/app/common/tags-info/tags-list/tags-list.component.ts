import { Component, Input, Output, EventEmitter } from '@angular/core';

import { Tag } from '../Tag';

@Component({
  selector: 'app-tags-list',
  templateUrl: './tags-list.component.html',
  styleUrls: ['./tags-list.component.css']
})
export class TagsListComponent {
  @Input() tagsList: Tag[];

  @Output() clickTag = new EventEmitter();

  testCall(tagName) {
    this.clickTag.emit(tagName);
  }
}
