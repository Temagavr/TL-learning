import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-favourites-header',
  templateUrl: './user-favourites-header.component.html',
  styleUrls: ['./user-favourites-header.component.css']
})
export class UserFavouritesHeaderComponent {
  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) {

  }
}
