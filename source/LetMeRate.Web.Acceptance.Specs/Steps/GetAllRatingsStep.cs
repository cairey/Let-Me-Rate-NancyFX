using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Web.Acceptance.Specs.Setup;
using NUnit.Framework;
using Nancy;
using Nancy.Json;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Steps
{

    [Binding]
    public class GetAllRatingsStep : NancyRequestWrapper
    {
        private BrowserResponse _response;

        [When(@"getting rating for my account")]
        public void WhenGettingRatingForMyAccount()
        {
            var accountKey = FeatureContext.Current["AccountKey2"];
            var response = Browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.189");
            });

            var responseString = response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<Dictionary<string, object>>(responseString);
            var tokenKey = result["TokenKey"];

            _response = Browser.Get(string.Format("/{0}/Ratings/All", tokenKey), with =>
            {
                with.HttpRequest();
            }); 
        }

        [Then(@"I should be able to see all my ratings")]
        public void ThenIShouldBeAbleToSeeAllMyRatings()
        {
            var responseString = _response.GetBodyAsString();
            var jss = new JavaScriptSerializer();

            Assert.IsNotEmpty(responseString);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
