import { Component } from '@angular/core';

@Component({
  selector: 'app-recipe-create-card',
  templateUrl: './recipe-create-card.component.html',
  styleUrls: ['./recipe-create-card.component.css']
})
export class RecipeCreateCardComponent {
  timeVariants: number[] = [];
  personsVariants: number[] = []

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
}
