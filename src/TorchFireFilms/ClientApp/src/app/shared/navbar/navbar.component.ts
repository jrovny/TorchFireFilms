import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { User } from 'oidc-client';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/core/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  user$: Observable<User>;
  smScreen = false;

  constructor(
    private authService: AuthService,
    private breakpointObserver: BreakpointObserver
  ) {
    this.user$ = this.authService.userChanged$;
    this.breakpointObserver
      .observe([Breakpoints.HandsetPortrait])
      .subscribe((result) => (this.smScreen = result.matches));
  }

  ngOnInit(): void {}

  authenticated() {
    return this.authService.authenticated();
  }

  signIn() {
    this.authService.signIn();
  }

  signOut() {
    this.authService.signOut();
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
