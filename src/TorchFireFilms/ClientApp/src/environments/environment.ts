export const environment = {
  production: false,
  baseUrl: 'https://localhost:5010',
  auth: {
    authority: 'https://test.accounts.torchfirefilms.com',
    redirectUri: 'https://localhost:5010/signin-redirect',
    postLogoutRedirectUri: 'https://localhost:5010/signout-callback-oidc',
  },
};
