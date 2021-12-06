import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-recipe-create-header',
  templateUrl: './recipe-create-header.component.html',
  styleUrls: ['./recipe-create-header.component.css']
})
export class RecipeCreateHeaderComponent {

  @Output() onCreateRecipeClick = new EventEmitter();

  createRecipeClick() {
    this.onCreateRecipeClick.emit();
  }

}
