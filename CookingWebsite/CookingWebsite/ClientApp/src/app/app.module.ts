import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { HomeModule } from './pages/home/home.module';
import { RecipesListPageModule } from './pages/recipes-list-page/recipes-list-page.module';

import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './common/header/header.component';
import { FooterComponent } from './common/footer/footer.component';
import { AppComponent } from './app.component';
import { UserInteractionService } from './common/services/user-interaction.service';
import { LoginModalComponent } from './common/modals/login-modal/login-modal.component';
import { RegistrationModalComponent } from './common/modals/registration-modal/registration-modal.component';
import { GreetingModalComponent } from './common/modals/greeting-modal/greeting-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginModalComponent,
    RegistrationModalComponent,
    GreetingModalComponent
  ],
  imports: [
    HomeModule,
    RecipesListPageModule,

    AppRoutingModule,

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [UserInteractionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
