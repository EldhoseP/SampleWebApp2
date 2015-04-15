using System;
namespace ExampleSetup.Manager.AcquiredTokenManager
{
    public interface AcquiredTokenManager
    {
        string ReturnOAuthTokenFromResource(string clientId, string clientSecret, string resourceId, string authority);
    }
}
