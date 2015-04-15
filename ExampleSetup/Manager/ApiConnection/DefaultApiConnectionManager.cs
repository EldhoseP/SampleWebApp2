using ExampleSetup.Manager;
using ExampleSetup.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace ExampleSetup.Manager.ApiConnection
{
    public class DefaultApiConnectionManager : ApiConnectionManager
    {
        private HttpClient Client { get; set; }

        public DefaultApiConnectionManager(HttpClient client)
        {
            Client = client;
        }
        public async Task<TokenResult> ReturnAPIKey(string api, String aquiredtoken)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", aquiredtoken);
            return await ConnectAndReturnAccessToken(api);
        }

        private async Task<TokenResult> ConnectAndReturnAccessToken(string api)
        {
            var response = await Client.GetAsync(new Uri(api).ToString());
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TokenResult>();
            }
            throw new Exception("Unable to connect, please check your settings from Direct ID");
        }
    }
}