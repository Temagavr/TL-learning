import { Routes, RouterModule } from '@angular/router';
import { RecipeDetailsComponent } from './recipe-details.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
  {
    path: 'recipes/:id',
    component: RecipeDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecipeDetailsRoutingModule { }
