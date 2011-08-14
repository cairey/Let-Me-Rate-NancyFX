using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
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
            Assert.AreEqual(38, response.GetBodyAsString().Length);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
