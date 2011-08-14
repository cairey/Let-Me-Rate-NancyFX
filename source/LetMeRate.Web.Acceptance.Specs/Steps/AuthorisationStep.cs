using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Nancy.Json;
using TechTalk.SpecFlow;
using LetMeRate.Web.Acceptance.Specs.Setup;
using Nancy;
using Nancy.Testing;

namespace LetMeRate.Web.Acceptance.Specs.Steps
{
    [Binding]
    public class AuthorisationStep : NancyRequestWrapper
    {
        private BrowserResponse response;

        [When(@"I want temp credetials supplying an IP Address and my secret account key")]
        public void WhenIWantTempCredetialsSupplyingAnIPAddressAndMySecretAccountKey()
        {
            var accountKey = FeatureContext.Current["AccountKey2"];
            response = Browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.186");
            });
        }

        [Then(@"I should receive temp credentials")]
        public void ThenIShouldReceiveTempCredentials()
        {
            var responseString = response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<Dictionary<string, object>>(responseString);

            Assert.AreEqual(36, ((string)result["TokenKey"]).Length);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
