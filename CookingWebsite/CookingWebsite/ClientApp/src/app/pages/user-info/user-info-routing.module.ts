import { Routes, RouterModule } from '@angular/router';
import { UserInfoComponent } from './user-info.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
  {
    path: 'user/info',
    component: UserInfoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserInfoRoutingModule { }
