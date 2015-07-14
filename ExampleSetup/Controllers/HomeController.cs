using ExampleSetup.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace ExampleSetup.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Presents a form for populating the credentials required to 
        /// establish a Direct ID API connection.
        /// </summary>
        public ActionResult Index()
        {
            return View(new CredentialsModel());
        }

        /// <summary>
        /// Handles the form post submitted by the <see cref="Index"/> view,
        /// using the supplied credentials
        /// </summary>
        [HttpPost]
        public async Task<ViewResult> Connect(CredentialsModel credentials)
        {
            var userSessionToken = await AcquireUserSessionToken(
                AcquireOAuthAccessToken(credentials),
                new Uri(credentials.API));
            
            return View("Widget", new WidgetModel(userSessionToken, credentials.FullCDNPath));
        }

        /// <summary>
        /// Obtains an OAuth access token which can then be used to make authorized calls
        /// to the Direct ID API.
        /// </summary>
        /// <remarks>
        /// <para>The returned value is expected to be included in the authentication header
        /// of subsequent API requests.</para>
        /// <para>As the returned value authenticates the application, API calls made using
        /// this value should only be made using server-side code.</para>
        /// </remarks>
        private static string AcquireOAuthAccessToken(CredentialsModel credentials)
        {
            TrimCredentialsModel(credentials);
            var context = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(
                credentials.Authority);

            var accessToken = context.AcquireToken(
                credentials.ResourceID,
                new Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential(
                    credentials.ClientID,
                    credentials.SecretKey));

            if (accessToken == null)
            {
                throw new InvalidOperationException(
                    "Unable to acquire access token from resource: " + credentials.ResourceID +
                    ".  Please check your settings from Direct ID.");
            }

            return accessToken.AccessToken;
        }

        private static void TrimCredentialsModel(CredentialsModel credentials)
        {
            credentials.API = credentials.API.Trim();
            credentials.Authority = credentials.Authority.Trim();
            credentials.ClientID = credentials.ClientID.Trim();
            credentials.ResourceID = credentials.ResourceID.Trim();
            credentials.SecretKey = credentials.SecretKey.Trim();
            credentials.FullCDNPath = credentials.FullCDNPath.Trim();
        }

        /// <summary>
        /// Queries <paramref name="apiEndpoint"/> with an http request
        /// authorized with <paramref name="authenticationToken"/>.
        /// </summary>
        private static async Task<string> AcquireUserSessionToken(
            string authenticationToken,
            Uri apiEndpoint)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", authenticationToken);

            var response = await httpClient.GetAsync(apiEndpoint);
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(
                    "Unable to acquire access token from endpoint: " + apiEndpoint +
                    ".  Please check your settings from Direct ID.");
            }

            var userSessionResponse = await response.Content.ReadAsAsync<UserSessionResponse>();
            return userSessionResponse.token;
        }
    }

}