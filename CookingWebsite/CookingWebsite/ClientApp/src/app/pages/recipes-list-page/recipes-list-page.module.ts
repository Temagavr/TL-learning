import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RecipesListPageRoutingModule } from './recipes-list-page-routing.module';

import { RecipesListPageComponent } from './recipes-list-page.component';
import { RecipesTitleComponent } from './title/title.component';
import { RecipesListComponent } from './recipes-list/recipes-list.component';
import { RecipeCardComponent } from '../../common/recipe-card/recipe-card.component';

@NgModule({
  declarations: [
    RecipesListPageComponent,
    RecipesTitleComponent,
    RecipesListComponent,
    RecipeCardComponent
  ],
  imports: [CommonModule, RecipesListPageRoutingModule],
  exports: [],
  providers: [],
})

export class RecipesListPageModule { }
