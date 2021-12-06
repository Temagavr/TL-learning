import { Component, Input } from '@angular/core';
import { AddRecipeDto } from '../add-recipe-dto';

@Component({
  selector: 'app-recipe-create-card',
  templateUrl: './recipe-create-card.component.html',
  styleUrls: ['./recipe-create-card.component.css']
})
export class RecipeCreateCardComponent {

  @Input() recipeData: AddRecipeDto;

  timeVariants: number[] = [];
  personsVariants: number[] = [];
  imgUrl: string = '';
  
  ngOnInit() {
    this.fillTimeVariants();
    this.fillPersonsVariants();
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
