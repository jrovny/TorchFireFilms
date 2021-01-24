export const environment = {
  production: false,
  auth: {
    authority: 'https://test.accounts.torchfirefilms.com',
    redirectUri: 'https://localhost:5010/signin-redirect',
    postLogoutRedirectUri: 'https://localhost:5010/signout-callback-oidc',
  },
};
