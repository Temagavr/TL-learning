import { Component, EventEmitter, Output, Input } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

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

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.events
      .subscribe((event: NavigationEnd) => {
        if (this.router.url == '/') {

          this.isHome = true;
          this.isRecipes = false;
          this.isFavourite = false;

        } else if (this.router.url == '/recipes') {

          this.isRecipes = true;
          this.isHome = false;
          this.isFavourite = false;

        } else if (this.router.url == '/favourite') {

          this.isFavourite = true;
          this.isHome = false;
          this.isRecipes = false;

        }
      });

    
  }
}
