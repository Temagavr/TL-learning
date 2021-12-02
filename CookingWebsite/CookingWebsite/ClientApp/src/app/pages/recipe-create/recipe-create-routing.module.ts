import { Routes, RouterModule } from '@angular/router';
import { RecipeCreateComponent } from './recipe-create.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
  {
    path: 'recipe/create',
    component: RecipeCreateComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecipeCreateRoutingModule { }