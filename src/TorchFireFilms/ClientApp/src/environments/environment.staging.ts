export const environment = {
  production: false,
  baseUrl: 'https://test.torchfirefilms.com',
  auth: {
    authority: 'https://test.accounts.torchfirefilms.com',
    redirectUri: 'https://test.torchfirefilms.com/signin-redirect',
    postLogoutRedirectUri:
      'https://test.torchfirefilms.com/signout-callback-oidc',
  },
};
