import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipe-create-header',
  templateUrl: './recipe-create-header.component.html',
  styleUrls: ['./recipe-create-header.component.css']
})
export class RecipeCreateHeaderComponent {

  constructor(private router: Router) {

  }

  isEdit: boolean = false;

  @Input() title: string;

  @Output() onCreateRecipeClick = new EventEmitter();

  @Output() onUpdateRecipeClick = new EventEmitter();

  ngOnInit() {
    if (this.router.url.includes('/edit'))
      this.isEdit = true;
  }

  createRecipeClick() {
    this.onCreateRecipeClick.emit();
  }

  updateRecipeClick() {
    this.onUpdateRecipeClick.emit();
  }

}
