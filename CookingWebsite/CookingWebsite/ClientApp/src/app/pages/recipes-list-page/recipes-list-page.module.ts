import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RecipesListPageRoutingModule } from './recipes-list-page-routing.module';

import { RecipesListPageComponent } from './recipes-list-page.component';
import { RecipesListComponent } from './recipes-list/recipes-list.component';

@NgModule({
  declarations: [
    RecipesListPageComponent,
    RecipesListComponent
  ],
  imports: [CommonModule, RecipesListPageRoutingModule],
  exports: [],
  providers: [],
})

export class RecipesListPageModule { }
