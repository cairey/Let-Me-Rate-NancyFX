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

            _response = Browser.Get(string.Format("/{0}/Ratings/Custom", accountKey), with =>
            {
                with.HttpRequest();
                with.Query("VideoID", "1234");
            }); 
        }

        [Then(@"I should be able to see all my ratings for my custom query")]
        public void ThenIShouldBeAbleToSeeAllMyRatingsForMyCustomQuery()
        {
            var responseString = _response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<List<Dictionary<string, object>>>(responseString);


            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }

    }
}
