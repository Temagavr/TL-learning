import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RecipesListPageRoutingModule } from './recipes-list-page-routing.module';

import { RecipesListPageComponent } from './recipes-list-page.component';
import { RecipesTitleComponent } from './title/title.component';
import { RecipesListComponent } from './recipes-list/recipes-list.component';

import { SharedModule } from '../../common/shared.module';
import { RecipeService } from '../../common/services/recipe.service';

@NgModule({
  declarations: [
    RecipesListPageComponent,
    RecipesTitleComponent,
    RecipesListComponent
  ],
  imports: [CommonModule, RecipesListPageRoutingModule, SharedModule],
  exports: [],
  providers: [RecipeService],
})

export class RecipesListPageModule { }
