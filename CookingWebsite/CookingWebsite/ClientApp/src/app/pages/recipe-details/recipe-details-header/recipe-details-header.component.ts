import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-recipe-details-header',
  templateUrl: './recipe-details-header.component.html',
  styleUrls: ['./recipe-details-header.component.css']
})
export class RecipeDetailsHeaderComponent {
  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) {

  }

  @Output() onDeleteRecipeClick = new EventEmitter();

  @Input() recipeTitle: string;

  goToEditRecipe() {
    this.router.navigate(['/recipes/edit', this.route.snapshot.params.id]);
  }

  deleteRecipeClick() {
    this.onDeleteRecipeClick.emit();
  }

}
