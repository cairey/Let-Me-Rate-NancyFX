using System.Collections.Generic;
using LetMeRate.Web.Acceptance.Specs.Setup;
using NUnit.Framework;
using Nancy;
using Nancy.Json;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Steps
{
    [Binding]
    public class CreateAccountStep : NancyRequestWrapper
    {
        private BrowserResponse _response;

        [When(@"creating an account with my email and password")]
        public void WhenCreatingAnAccountWithMyEmailAndPassword()
        {
            _response = Browser.Post("/Account/Create", with =>
            {
                with.HttpRequest();
                with.FormValue("EmailAddress", "example@example.com");
                with.FormValue("Password", "Pa55word");
                with.FormValue("RateOutOf", "100");
            }); 
        }

        [Then(@"I should be able to see my created account")]
        public void ThenIShouldBeAbleToSeeMyCreatedAccount()
        {
            var responseString = _response.GetBodyAsString();
            JavaScriptSerializer s = new JavaScriptSerializer();
            var res = s.Deserialize<Dictionary<string, object>>(responseString);

            Assert.IsNotNull(res["AccountKey"]);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
