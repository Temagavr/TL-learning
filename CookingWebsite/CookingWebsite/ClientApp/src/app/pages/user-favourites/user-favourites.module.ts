import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { UserFavouritesRoutingModule } from './user-favourites-routing.module';

import { UserFavouritesComponent } from './user-favourites.component';
import { UserFavouritesHeaderComponent } from './user-favourites-header/user-favourites-header.component';

import { SharedModule } from '../../common/shared.module';
import { UserFavouritesService } from './user-favourites.sevice';

@NgModule({
  declarations: [
    UserFavouritesComponent,
    UserFavouritesHeaderComponent
  ],
  imports: [CommonModule, UserFavouritesRoutingModule, SharedModule],
  exports: [],
  providers: [ UserFavouritesService ],
})

export class UserFavouritesModule { }
