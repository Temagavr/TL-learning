import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { HomeRoutingModule } from './home-routing.module';

import { HomeComponent } from './home.component';

import { GreetingComponent } from './greeting/greeting.component';
import { DayRecipeComponent } from './day-recipe/day-recipe.component';
import { HomeSearchComponent } from './home-search/home-search.component';

import { TagsInfoComponent } from '../../common/tags-info/tags-info.component';
import { TagsTypeComponent } from '../../common/tags-info/tags-type/tags-type.component';

@NgModule({
  declarations: [
    HomeComponent,
    GreetingComponent,
    DayRecipeComponent,
    HomeSearchComponent,

    TagsInfoComponent,
    TagsTypeComponent,

  ],
  imports: [CommonModule, HomeRoutingModule],
  providers: [],
})
export class HomeModule { }
