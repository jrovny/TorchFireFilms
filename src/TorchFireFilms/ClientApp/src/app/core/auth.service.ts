import { Injectable } from '@angular/core';
import { User, UserManager, WebStorageStateStore } from 'oidc-client';
import { from, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  userManager: UserManager;
  user: User;

  constructor() {
    this.userManager = new UserManager({
      authority: 'https://localhost:5001',
      client_id: 'spa',
      redirect_uri: 'https://localhost:5010/signin-redirect',
      response_type: 'code',
      scope: 'openid profile scope1',
      post_logout_redirect_uri: 'https://localhost:5010',
      // userStore: new WebStorageStateStore({
      //   store: window.localStorage,
      // }),
    });
  }

  signIn(): Observable<any> {
    return from(this.userManager.signinRedirect());
  }

  signInCallback() {
    console.log('signInCallback() called');
    return from(this.userManager.signinRedirectCallback());
  }

  getAccessToken() {
    return this.user ? this.user.access_token : '';
  }

  isSignedIn(): Observable<boolean> {
    return from(this.userManager.getUser()).pipe(
      map((user) => {
        return user && !user.expired;
      })
    );
  }

  signOut() {
    return this.userManager.signoutRedirect();
  }

  getUser() {
    return from(this.userManager.getUser());
  }
}
