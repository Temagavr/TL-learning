import { Component, Input } from '@angular/core';
import { RecipeIngredientDto } from '../../../Dtos/recipe-ingredient-dto';

@Component({
  selector: 'app-recipe-create-body',
  templateUrl: './recipe-create-body.component.html',
  styleUrls: ['./recipe-create-body.component.css']
})
export class RecipeCreateBodyComponent {

  @Input() steps: string[];

  @Input() ingredients: RecipeIngredientDto[];

  addIngredient() {
    this.ingredients.push({
      title: '',
      items: []
    });
  }

  addStep() {
    this.steps.push('');
  }

  removeIngredient(index: number) {
    this.ingredients.splice(index, 1);
  }

  removeStep(index: number) {
    this.steps.splice(index, 1);
  }

  trackByFn(index: any, item: any) {
    return index;
  }
}
