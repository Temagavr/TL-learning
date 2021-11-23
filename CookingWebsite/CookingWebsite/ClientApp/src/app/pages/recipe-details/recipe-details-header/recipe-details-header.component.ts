import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-recipe-details-header',
  templateUrl: './recipe-details-header.component.html',
  styleUrls: ['./recipe-details-header.component.css']
})
export class RecipeDetailsHeaderComponent {

  @Input() recipeTitle: string;
  
}
