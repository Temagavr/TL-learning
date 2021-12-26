import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

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
import { RecipeLikeService } from './recipe-card/recipe-like.service';

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
  imports: [CommonModule, FormsModule],
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
  ],
  providers:[RecipeLikeService]
})
export class SharedModule { }
