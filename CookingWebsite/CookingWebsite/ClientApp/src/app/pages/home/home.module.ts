import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { HomeRoutingModule } from './home-routing.module';

import { HomeComponent } from './home.component';

import { GreetingComponent } from './greeting/greeting.component';
import { DayRecipeComponent } from './day-recipe/day-recipe.component';
import { HomeSearchComponent } from './home-search/home-search.component';

import { SharedModule } from '../../common/shared.module';
import { HomeService } from './home.service';

@NgModule({
  declarations: [
    HomeComponent,
    GreetingComponent,
    DayRecipeComponent,
    HomeSearchComponent
  ],
  imports: [CommonModule, HomeRoutingModule, SharedModule],
  providers: [HomeService],
})
export class HomeModule { }
