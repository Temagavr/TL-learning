import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { GreetingComponent } from './greeting/greeting.component';
import { TagsInfoComponent } from './tags-info/tags-info.component';
import { TagsTypeComponent } from './tags-info/tags-type/tags-type.component';
import { FooterComponent } from './footer/footer.component';
import { DayRecipeComponent } from './day-recipe/day-recipe.component';
import { HomeSearchComponent } from './home-search/home-search.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GreetingComponent,
    TagsInfoComponent,
    TagsTypeComponent,
    DayRecipeComponent,
    HomeSearchComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
