using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Specs
{
    [Binding]
    public class CreateAccountSteps
    {
        private Browser _browser;
        private BrowserResponse _response;

        [Given(@"I am creating an account")]
        public void GivenIAmCreatingAnAccount()
        {
             _browser = new Browser(new TestWebBootstrapper());
        }

        [When(@"creating an account with my email and password")]
        public void WhenCreatingAnAccountWithMyEmailAndPassword()
        {
            _response = _browser.Post("/Account/Create", with =>
            {
                with.HttpRequest();
                with.FormValue("EmailAddress", "example@example.com");
                with.FormValue("Password", "Pa55word");
            }); 
        }

        [Then(@"I should be able to see my created account")]
        public void ThenIShouldBeAbleToSeeMyCreatedAccount()
        {
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
