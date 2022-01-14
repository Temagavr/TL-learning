import { Routes, RouterModule } from '@angular/router';
import { UserFavouritesComponent } from './user-favourites.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
  {
    path: 'favourites',
    component: UserFavouritesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserFavouritesRoutingModule { }
