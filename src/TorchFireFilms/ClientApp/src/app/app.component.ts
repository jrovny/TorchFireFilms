import { Component } from '@angular/core';
import * as Player from '@vimeo/player/dist/player.js';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'angular-sample-app';
  player: Player;

  constructor() {
    this.player = new Player();
  }
}
