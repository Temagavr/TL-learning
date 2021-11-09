import { Routes, RouterModule } from '@angular/router';
import { RecipesListPageComponent } from './recipes-list-page.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {
    path: 'recipes',
    component: RecipesListPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecipesListPageRoutingModule { }
