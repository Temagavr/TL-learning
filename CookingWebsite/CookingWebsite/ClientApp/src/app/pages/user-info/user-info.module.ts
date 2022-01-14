import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { UserInfoComponent } from './user-info.component';
import { UserInfoHeaderComponent } from './user-info-header/user-info-header.component';
import { UserInfoCardComponent } from './user-info-card/user-info-card.component';
import { UserInfoMetricComponent } from './user-info-metric/user-info-metric.component';
import { UserInfoRecipesListComponent } from './user-info-recipes-list/user-info-recipes-list.component';

import { UserInfoRoutingModule } from './user-info-routing.module';

import { UserInfoService } from './user-info.service';

import { SharedModule } from '../../common/shared.module';

@NgModule({
  declarations: [
    UserInfoComponent,
    UserInfoHeaderComponent,
    UserInfoCardComponent,
    UserInfoMetricComponent,
    UserInfoRecipesListComponent
  ],
  imports: [CommonModule, UserInfoRoutingModule, FormsModule, SharedModule],
  exports: [],
  providers: [ UserInfoService ],
})

export class UserInfoModule { }
