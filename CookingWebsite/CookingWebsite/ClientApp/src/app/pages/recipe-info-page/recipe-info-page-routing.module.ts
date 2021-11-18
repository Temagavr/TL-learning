import { Routes, RouterModule } from '@angular/router';
import { RecipeInfoPageComponent } from './recipe-info-page.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
  {
    path: 'recipes/1',
    component: RecipeInfoPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecipeInfoPageRoutingModule { }
