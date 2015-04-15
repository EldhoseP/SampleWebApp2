using ExampleSetup.Manager.ClientCredentails;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleSetup.Manager.ClientCredentials
{
    public class DefaultClientCredentialsFactory : ClientCredentialFactory
    {
        public ClientCredential generateCredentials(String clientId, String clientSecret)
        {
            return new ClientCredential(clientId, clientSecret);
        }
    }
}