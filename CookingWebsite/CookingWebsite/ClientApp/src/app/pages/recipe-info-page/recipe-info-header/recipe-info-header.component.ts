import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-recipe-info-header',
  templateUrl: './recipe-info-header.component.html',
  styleUrls: ['./recipe-info-header.component.css']
})
export class RecipeInfoHeaderComponent {

  @Input() recipeTitle: string;
  
}
