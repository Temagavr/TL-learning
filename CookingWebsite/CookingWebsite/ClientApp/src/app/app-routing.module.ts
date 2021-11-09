import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

const routes: Routes = [
  //{ path: '', loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule), pathMatch: 'full' },
  //{ path: 'recipes', loadChildren: () => import('./pages/recipes-list-page/recipes-list-page.module').then(m => m.RecipesListPageModule) }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
