using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSetup.Manager.ClientCredentails
{
    public interface ClientCredentialFactory
    {
        ClientCredential generateCredentials(string clientId, string clientSecret);
    }
}
