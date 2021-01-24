export const environment = {
  production: false,
  auth: {
    authority: 'https://test.accounts.torchfirefilms.com',
    redirectUri: 'https://localhost:5010.com/signin-redirect',
    postLogoutRedirectUri: 'https://localhost:5010.com/signout-callback-oidc',
  },
};
