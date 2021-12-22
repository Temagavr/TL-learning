import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../../common/services/account.service';
import { AuthorizedUserDto } from '../../../Dtos/authorized-user-dto';

@Component({
  selector: 'app-recipes-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.css']
})
export class RecipesTitleComponent {

  constructor(
    private accountService: AccountService,
    private router: Router
  ) {}

  addRecipeClick() {
    this.accountService.getUser().then((user: AuthorizedUserDto) => {
      if (user.id != 0) {
        this.router.navigate(['/recipes/create']);
      }
    });
  }

}
