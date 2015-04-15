using ExampleSetup.Manager;
using ExampleSetup.Manager.AcquiredTokenManager;
using ExampleSetup.Manager.ApiConnection;
using ExampleSetup.Manager.AuthenticationContext;
using ExampleSetup.Manager.ClientCredentials;
using ExampleSetup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExampleSetup.Controllers
{
    public class HomeController : Controller
    {
        private AcquiredTokenManager AcquiredTokenManager { get; set; }
        private ApiConnectionManager ApiConnectionManager { get; set; }
        public HomeController()
        {
            AcquiredTokenManager = new DefaultAcquiredTokenManager(new DefaultAuthenticationContextFactory(), new DefaultClientCredentialsFactory());
            ApiConnectionManager = new DefaultApiConnectionManager(new HttpClient());
        }

        public HomeController(AcquiredTokenManager tokenManager, ApiConnectionManager apiConnectionManager)
        {
            AcquiredTokenManager = tokenManager;
            ApiConnectionManager = apiConnectionManager;

        }

        public ActionResult Index()
        {
            CredentialsModel m = new CredentialsModel();
            return View(m);
        }

        [HttpPost]
        public async Task<ViewResult> Connect(CredentialsModel model)
        {
            var token = await ApiConnectionManager.ReturnAPIKey(model.API, AcquiredTokenManager.ReturnOAuthTokenFromResource(model.ClientID, model.SecretKey, model.ResourceID, model.Authority));

            return View("Widget", new WidgetModel(token.token, model.Version));
        }
    }

}