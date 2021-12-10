import { Component, Input } from '@angular/core';
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

  @Input() recipeTitle: string;

  goToEditRecipe() {
    this.router.navigate(['/recipes/edit', this.route.snapshot.params.id]);
  }

}
