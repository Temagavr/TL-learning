import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { RecipeCard } from '../../../common/recipe-card/recipe-card';
import { AddRecipeDto } from '../add-recipe-dto';

@Component({
  selector: 'app-recipe-create-card',
  templateUrl: './recipe-create-card.component.html',
  styleUrls: ['./recipe-create-card.component.css']
})
export class RecipeCreateCardComponent {

  constructor(private router: Router) {

  }

  @Input() recipeData: AddRecipeDto;

  @Input() allTags: string;

  timeVariants: number[] = [];
  personsVariants: number[] = [];
  imgUrl: string = '';

  isEdit: boolean = false;
  
  ngOnInit() {
    this.fillTimeVariants();
    this.fillPersonsVariants();

    if (this.router.url.includes('/edit')) {
      this.isEdit = true;
      this.imgUrl = this.recipeData.imageUrl;
    }
  }

  fillTimeVariants() {
    for (var i = 5; i < 150; i += 5) {
      this.timeVariants.push(i);
    }
  }

  fillPersonsVariants() {
    for (var i = 1; i < 10; i++) {
      this.personsVariants.push(i);
    }
  }

  loadClick() {
    var input = document.getElementById('imgInput');
    input.click();
  }

  preloadImg(event) {
    const file = (event.target as HTMLInputElement).files[0];

    // File Preview
    const reader = new FileReader();
    reader.onload = () => {
      this.imgUrl = reader.result as string;
    }

    reader.onerror = () => {
      this.imgUrl = '';
    }

    if (file) {
      reader.readAsDataURL(file);
      this.recipeData.image = file;
    }
      
  }
}
