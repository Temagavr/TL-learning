import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RecipeCreateRoutingModule } from './recipe-create-routing.module';
import { FormsModule } from '@angular/forms';

import { RecipeCreateComponent } from './recipe-create.component';
import { RecipeCreateHeaderComponent } from './recipe-create-header/recipe-create-header.component';
import { RecipeCreateCardComponent } from './recipe-create-card/recipe-create-card.component';
import { RecipeCreateBodyComponent } from './recipe-create-body/recipe-create-body.component';

import { RecipeUpdateComponent } from './recipe-update.component';

import { SharedModule } from '../../common/shared.module';
import { RecipeCreateUpdateService } from './recipe-create-update.service';

@NgModule({
  declarations: [
    RecipeCreateComponent,
    RecipeCreateHeaderComponent,
    RecipeCreateCardComponent,
    RecipeCreateBodyComponent,

    RecipeUpdateComponent
  ],
  imports: [CommonModule, RecipeCreateRoutingModule, FormsModule, SharedModule],
  exports: [],
  providers: [RecipeCreateUpdateService],
})

export class RecipeCreateModule { }
