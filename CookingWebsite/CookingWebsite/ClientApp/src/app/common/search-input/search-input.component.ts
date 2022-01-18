import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-search-input',
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.css']
})
export class SearchInputComponent {

  @Input() recommendsTags: string[];

  @Output() onSearchClick = new EventEmitter();

  inputValue = '';

  callInput(tagName) {
    this.inputValue = tagName;
  }

  recomendTagClick(recomendValue) {
    this.inputValue = recomendValue;
  }

  searchClick() {
    this.onSearchClick.emit(this.inputValue);
  }
}
