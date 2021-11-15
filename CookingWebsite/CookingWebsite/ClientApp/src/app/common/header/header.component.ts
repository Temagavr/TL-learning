import { Component, EventEmitter, Output, Input } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

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

  enterByUser() {
    this.onUserEnterClicked.emit();
  }

  LogOut() {
    this.onUserLogOutClicked.emit();
  }
    
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.events
      .subscribe((event: NavigationEnd) => {
        if (this.router.url == '/') {

          this.isHome = true;
          this.isRecipes = false;
          this.isFavourites = false;

        } else if (this.router.url == '/recipes') {

          this.isRecipes = true;
          this.isHome = false;
          this.isFavourites = false;

        } else if (this.router.url == '/favourite') {

          this.isFavourites = true;
          this.isHome = false;
          this.isRecipes = false;

        }
      });
  }
}
