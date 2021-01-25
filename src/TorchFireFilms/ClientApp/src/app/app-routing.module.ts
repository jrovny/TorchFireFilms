import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { CallbackComponent } from './auth/callback/callback.component';
import { SignoutRedirectCallbackComponent } from './auth/signout-redirect-callback/signout-redirect-callback.component';
import { BrowseComponent } from './films/components/browse/browse.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: 'signin-redirect', component: CallbackComponent },
  {
    path: 'signout-callback-oidc',
    component: SignoutRedirectCallbackComponent,
  },
  { path: 'browse', component: BrowseComponent },
  { path: '', component: BrowseComponent },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
