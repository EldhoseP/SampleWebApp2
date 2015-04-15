
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleSetup.Manager.AuthenticationContext
{
    public class DefaultAuthenticationContextFactory : ExampleSetup.Manager.AuthenticationContext.AuthenticationContextFactory
    {
        public Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext GenerateAuthenticationContext(string authority)
        {
            return new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authority);
        }
    }
}