using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleSetup.Controllers;
using ExampleSetup.Manager.AcquiredTokenManager;
using FakeItEasy;
using ExampleSetup.Manager.ApiConnection;
using ExampleSetup.Models;
using System.Threading.Tasks;

namespace ExampleSetup.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController UnderTest;

        private AcquiredTokenManager FakedAcquiredTokenManager;
        private ApiConnectionManager FakedApiConnectionManager;
        [TestInitialize]
        public void Index()
        {
            FakedAcquiredTokenManager = A.Fake<AcquiredTokenManager>();
            FakedApiConnectionManager = A.Fake<ApiConnectionManager>();
            UnderTest = new HomeController(FakedAcquiredTokenManager, FakedApiConnectionManager);
        }

        [TestMethod]
        public void Make_Sure_The_Index_Is_Populated_With_An_Empty_Index()
        {
            var result = UnderTest.Index() as ViewResult;
            Assert.IsNotNull(result);
            var model = result.Model as CredentialsModel;
            Assert.IsNull(model.ClientID);
            Assert.IsNull(model.API);
            Assert.IsNull(model.SecretKey);
            Assert.IsNull(model.ResourceID);
            Assert.IsNull(model.Version);
        }

        [TestMethod]
        public void Make_Sure_Version_Is_Not_Modified_During_Connect()
        {
            A.CallTo(() => FakedAcquiredTokenManager.ReturnOAuthTokenFromResource("clientid", "secretkey","resourceID", "autheticationContextPath")).Returns("accToken");
            A.CallTo(() => FakedApiConnectionManager.ReturnAPIKey("api", "accToken")).Returns(new TokenResult() { token = "bob", reference = "ref" });
            var result = UnderTest.Connect(new CredentialsModel() { API = "api", ClientID = "clientid", ResourceID = "resourceID", Version = "version", SecretKey = "secretkey", Authority = "autheticationContextPath" }) as Task<ViewResult>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Result);
            WidgetModel model = result.Result.Model as WidgetModel;
            Assert.IsTrue(model.Version == "version");
            Assert.IsTrue(model.Token == "bob");
        }
    }
}
