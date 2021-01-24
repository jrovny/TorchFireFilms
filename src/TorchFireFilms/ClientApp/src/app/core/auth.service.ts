import { Injectable } from '@angular/core';
import { User, UserManager, WebStorageStateStore } from 'oidc-client';
import { from, Observable, of, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private user$ = new Subject<User>();

  userManager: UserManager;
  user: User = null;
  userChanged$ = this.user$.asObservable();

  constructor() {
    this.userManager = new UserManager({
      authority: 'https://test.accounts.torchfirefilms.com', //'https://localhost:5001',
      client_id: 'spa',
      redirect_uri: 'https://localhost:5010/signin-redirect',
      response_type: 'code',
      scope: 'openid profile scope1',
      post_logout_redirect_uri: 'https://localhost:5010/signout-callback-oidc',
      userStore: new WebStorageStateStore({
        store: window.localStorage,
      }),
    });

    this.userManager.getUser().then((user) => {
      this.user = user;
    });
  }

  signIn(): Observable<any> {
    return from(this.userManager.signinRedirect());
  }

  signInCallback() {
    return this.userManager.signinRedirectCallback().then((user) => {
      this.user = user;
      this.user$.next(user);
    });
  }

  getAccessToken() {
    return this.user ? this.user.access_token : '';
  }

  signOut() {
    return this.userManager.signoutRedirect();
  }

  signOutCallBack() {
    this.user = null;
    return from(this.userManager.signoutRedirectCallback());
  }

  getUser() {
    return from(this.userManager.getUser());
  }

  authenticated() {
    return this.user && !this.user.expired;
  }
}
