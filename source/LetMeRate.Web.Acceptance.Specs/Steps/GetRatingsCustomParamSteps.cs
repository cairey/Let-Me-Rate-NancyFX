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
    public class GetRatingsCustomParamSteps : NancyRequestWrapper
    {
        private BrowserResponse _response;

        [When(@"getting ratings for my account and and my custom parameter")]
        public void WhenGettingRatingsForMyAccountAndAndMyCustomParameter()
        {
            var accountKey = FeatureContext.Current["AccountKey3"];
            var response = Browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.189");
            });

            var responseString = response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<Dictionary<string, object>>(responseString);
            var tokenKey = result["TokenKey"];

            _response = Browser.Get(string.Format("/{0}/Ratings/Custom", tokenKey), with =>
            {
                with.HttpRequest();
                with.Query("RelatedContent", "1337");
            }); 
        }

        [Then(@"I should be able to see all my ratings for my custom query")]
        public void ThenIShouldBeAbleToSeeAllMyRatingsForMyCustomQuery()
        {
            var responseString = _response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<List<Dictionary<string, object>>>(responseString);

            Assert.IsNotEmpty(responseString);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }

    }
}
