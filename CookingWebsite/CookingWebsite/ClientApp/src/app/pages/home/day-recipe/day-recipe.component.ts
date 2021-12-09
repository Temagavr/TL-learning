import { Component, Input } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

import { DayRecipeDto } from '../day-recipe-dto';

@Component({
  selector: 'app-day-recipe',
  templateUrl: './day-recipe.component.html',
  styleUrls: ['./day-recipe.component.css']
})
export class DayRecipeComponent {
  constructor(private sanitizer: DomSanitizer
  ) {
  }

  baseImagesPath: string = '../../../assets/'; // Здесь наверное должен быть полный путь на устройстве 

  imageSafeUrl: SafeUrl;

  @Input() dayRecipe: DayRecipeDto;

  ngOnInit() {
    let fullUrl: string = this.baseImagesPath + this.dayRecipe.image;
    this.imageSafeUrl = this.sanitizer.bypassSecurityTrustUrl(fullUrl);
  }
}
