import { Component, Input } from '@angular/core';

import { Tag } from '../Tag';

@Component({
  selector: 'app-tags-type',
  templateUrl: './tags-type.component.html',
  styleUrls: ['./tags-type.component.css']
})
export class TagsTypeComponent {

  @Input() tag: Tag

}
