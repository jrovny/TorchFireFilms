import { Component } from '@angular/core';
import { User } from 'oidc-client';
import { Observable } from 'rxjs';
import { AuthService } from './core/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'angular-sample-app';
  user$: Observable<User>;

  constructor(private authService: AuthService) {
    this.user$ = this.authService.userChanged$;
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
      let lastName = user.profile.family_name ?? '';
      let firstName = user.profile.given_name ?? '';

      // console.log(
      //   firstName.substring(0, 1).toUpperCase() +
      //     lastName.substring(0, 1).toUpperCase()
      // );

      return (
        firstName.substring(0, 1).toUpperCase() +
        lastName.substring(0, 1).toUpperCase()
      );
    } else {
      return 'U';
    }
  }
}
