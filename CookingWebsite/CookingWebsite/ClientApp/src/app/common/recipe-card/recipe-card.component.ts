import { ChangeDetectionStrategy, Component, Input, OnChanges } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Router } from '@angular/router';

import { RecipeCard } from './recipe-card';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RecipeCardComponent {

  constructor(private router: Router,
    private sanitizer: DomSanitizer
  ) {
  }

  @Input() recipeInfo: RecipeCard;

  baseImagesPath: string = '../../../assets/'; // Здесь наверное должен быть полный путь на устройстве 

  imageSafeUrl: SafeUrl;

  rightPersons: string;

  ngOnInit(): void {
    let fullUrl: string = this.baseImagesPath + this.recipeInfo.imageUrl;
    this.imageSafeUrl = this.sanitizer.bypassSecurityTrustUrl(fullUrl);

    if (this.recipeInfo.tags.length > 0)
      this.recipeInfo.tags = this.recipeInfo.tags.slice(0, 3);

    if (this.recipeInfo.personsCount == 1) {
      this.rightPersons = 'персону';
    } else if (this.recipeInfo.personsCount > 1 && this.recipeInfo.personsCount < 5) {
      this.rightPersons = 'персоны';
    } else {
      this.rightPersons = 'персон';
    }
  }

  likeRecipe() {
    this.recipeInfo.isLiked = !this.recipeInfo.isLiked;
    if (this.recipeInfo.isLiked) {
      this.recipeInfo.likesCount = this.recipeInfo.likesCount + 1;
    } else {
      this.recipeInfo.likesCount = this.recipeInfo.likesCount - 1;
    }
  }

  favouriteRecipe() {
    this.recipeInfo.isFavourite = !this.recipeInfo.isFavourite;
    if (this.recipeInfo.isFavourite) {
      this.recipeInfo.favouritesCount = this.recipeInfo.favouritesCount + 1;
    } else {
      this.recipeInfo.favouritesCount = this.recipeInfo.favouritesCount - 1;
    }
  }

  chooseRecipe() {
    this.router.navigate(['/recipes/details', this.recipeInfo.id]);
  }
}
