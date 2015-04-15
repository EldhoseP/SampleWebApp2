using ExampleSetup.Manager.AuthenticationContext;
using ExampleSetup.Manager.ClientCredentails;
using System;

namespace ExampleSetup.Manager.AcquiredTokenManager
{
    public class DefaultAcquiredTokenManager : ExampleSetup.Manager.AcquiredTokenManager.AcquiredTokenManager
    {
        private AuthenticationContextFactory AuthenticationContextManager { get; set; }

        private ClientCredentialFactory ClientCredentialManager { get; set; }

        public DefaultAcquiredTokenManager(AuthenticationContextFactory manager, ClientCredentialFactory credentials)
        {
            this.AuthenticationContextManager = manager;
            this.ClientCredentialManager = credentials;
        }
        public string ReturnOAuthTokenFromResource(string clientId, string clientSecret, String resourceId, string authority)
        {
            var context = AuthenticationContextManager.GenerateAuthenticationContext(authority);

            var result = context.AcquireToken(resourceId, ClientCredentialManager.generateCredentials(clientId, clientSecret));
            return result != null ? result.AccessToken : string.Empty;
        }

    }
}