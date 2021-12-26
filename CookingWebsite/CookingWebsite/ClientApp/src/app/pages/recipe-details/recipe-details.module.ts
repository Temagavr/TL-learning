import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RecipeDetailsRoutingModule } from './recipe-details-routing.module';

import { RecipeDetailsComponent } from './recipe-details.component';
import { RecipeDetailsHeaderComponent } from './recipe-details-header/recipe-details-header.component';
import { RecipeDetailsBodyComponent } from './recipe-details-body/recipe-details-body.component';

import { SharedModule } from '../../common/shared.module';
import { RecipeDetailsService } from './recipe-details.service';

@NgModule({
  declarations: [
    RecipeDetailsComponent,
    RecipeDetailsHeaderComponent,
    RecipeDetailsBodyComponent
  ],
  imports: [CommonModule, RecipeDetailsRoutingModule, SharedModule],
  exports: [],
  providers: [RecipeDetailsService],
})

export class RecipeDetailsModule { }
