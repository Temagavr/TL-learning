import { Component, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  @Input() userName: string;

  @Output() onUserEnterClicked = new EventEmitter();

  @Output() onUserLogOutClicked = new EventEmitter();

  enterByUser() {
    this.onUserEnterClicked.emit();
  }

  LogOut() {
    this.onUserLogOutClicked.emit();
  }

  isHome = false;

  isRecipes = false;

  isFavourite = false;
    
  changePage(pageTitle:string) {
    if (pageTitle == 'home') {

      this.isHome = true;
      this.isRecipes = false;
      this.isFavourite = false;

    } else if (pageTitle == 'recipes') {

      this.isRecipes = true;
      this.isHome = false;
      this.isFavourite = false;

    } else if (pageTitle == 'favourite') {

      this.isFavourite = true;
      this.isHome = false;
      this.isRecipes = false;

    }

    console.log(pageTitle);
  }
}
