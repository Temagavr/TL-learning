import { Component, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  @Input() userName: string;

  @Input() isHome: boolean;

  @Input() isRecipes: boolean;

  @Input() isFavourites: boolean;

  @Output() onUserEnterClicked = new EventEmitter();

  @Output() onUserLogOutClicked = new EventEmitter();

  @Output() onNavMenuClicked = new EventEmitter();

  enterByUser() {
    this.onUserEnterClicked.emit();
  }

  LogOut() {
    this.onUserLogOutClicked.emit();
  }
    
  changePage(pageTitle: string) {
    console.log(pageTitle);
    this.onNavMenuClicked.emit(pageTitle);
  }
}
