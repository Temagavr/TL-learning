import { Component } from '@angular/core';

export interface Tag {
  iconUrl: string
  title: string
  description: string
}

export interface DayRecipe {
  imageUrl: string
  title: string
  description: string

  likes: Number,
  time: Number
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
}
