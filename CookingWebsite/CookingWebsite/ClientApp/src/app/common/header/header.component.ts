import { Component, EventEmitter, Output, Input } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Link } from './link';

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
    
  constructor(private router: Router) { }

  linksList: Link[] = [
    { name: 'Главная', url: '/', isActive: false },
    { name: 'Рецепты', url: '/recipes', isActive: false },
    { name: 'Избранное', url: '/favourites', isActive: false }
  ];

  ngOnInit(): void {

    this.router.events
      .subscribe((event: NavigationEnd) => {
        this.linksList.forEach(function (link) {
          link.isActive = false;
        });

        var urlElems = this.router.url.split('/');
        var mainUrl = `/${urlElems[1]}`;

        if (this.linksList.some(x => x.url == mainUrl)) {
          this.linksList.filter(x => x.url == mainUrl)[0].isActive = true;
        }
      });
  }

}
