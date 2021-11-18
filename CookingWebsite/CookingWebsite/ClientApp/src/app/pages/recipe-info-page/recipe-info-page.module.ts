import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RecipeInfoPageRoutingModule } from './recipe-info-page-routing.module';

import { RecipeInfoPageComponent } from './recipe-info-page.component';
import { RecipeInfoHeaderComponent } from './recipe-info-header/recipe-info-header.component';
import { RecipeInfoBodyComponent } from './recipe-info-body/recipe-info-body.component';

import { SharedModule } from '../../common/shared.module';

@NgModule({
  declarations: [
    RecipeInfoPageComponent,
    RecipeInfoHeaderComponent,
    RecipeInfoBodyComponent
  ],
  imports: [CommonModule, RecipeInfoPageRoutingModule, SharedModule],
  exports: [],
  providers: [],
})

export class RecipeInfoPageModule { }
