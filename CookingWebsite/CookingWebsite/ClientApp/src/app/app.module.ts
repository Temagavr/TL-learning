import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { HomeModule } from './pages/home/home.module';
import { RecipesListPageModule } from './pages/recipes-list-page/recipes-list-page.module';
import { RecipeDetailsModule } from './pages/recipe-details/recipe-details.module';
import { RecipeCreateModule } from './pages/recipe-create/recipe-create.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UserInteractionService } from './common/services/user-interaction.service';
import { AccountService } from './common/services/account.service';

import { SharedModule } from './common/shared.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HomeModule,
    RecipesListPageModule,
    RecipeDetailsModule,
    RecipeCreateModule,

    AppRoutingModule,

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    SharedModule
  ],
  providers: [UserInteractionService, AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
