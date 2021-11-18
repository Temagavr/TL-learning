import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

import { GreetingModalComponent } from './modals/greeting-modal/greeting-modal.component';
import { LoginModalComponent } from './modals/login-modal/login-modal.component';
import { RegistrationModalComponent } from './modals/registration-modal/registration-modal.component';

import { TagsTypeComponent } from './tags-info/tags-type/tags-type.component';
import { TagsListComponent } from './tags-info/tags-list/tags-list.component';

import { SearchInputComponent } from './search-input/search-input.component';
import { RecipeCardComponent } from './recipe-card/recipe-card.component';
import { GoBackButtonComponent } from './go-back-button/go-back-button.component';

@NgModule({
  declarations: [
    TagsTypeComponent,
    TagsListComponent,
    HeaderComponent,
    FooterComponent,
    GreetingModalComponent,
    LoginModalComponent,
    RegistrationModalComponent,
    SearchInputComponent,
    RecipeCardComponent,
    GoBackButtonComponent
  ],
  imports: [CommonModule],
  exports: [
    TagsTypeComponent,
    HeaderComponent,
    FooterComponent,
    GreetingModalComponent,
    LoginModalComponent,
    RegistrationModalComponent,
    TagsListComponent,
    SearchInputComponent,
    RecipeCardComponent,
    GoBackButtonComponent
  ]
})
export class SharedModule { }
