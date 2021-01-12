import { Component } from '@angular/core';
import { AuthService } from './core/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'angular-sample-app';

  constructor(private authService: AuthService) {
    // this.authService.getUser().subscribe((user) => console.log('user', user));
  }

  signIn() {
    this.authService.signIn();
  }

  signOut() {
    this.authService.signOut();
  }

  authenticated() {
    return this.authService.authenticated();
  }

  getUserInitials() {
    let user = this.authService.user;

    if (user) {
      return (
        user.profile.given_name.substring(0, 1).toUpperCase() +
        user.profile.family_name.substring(0, 1).toUpperCase()
      );
    } else {
      return '';
    }
  }
}
