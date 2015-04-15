using System;
namespace ExampleSetup.Manager.AuthenticationContext
{
    public interface AuthenticationContextFactory
    {
        Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext GenerateAuthenticationContext(string authenticationContextPath);
    }
}
