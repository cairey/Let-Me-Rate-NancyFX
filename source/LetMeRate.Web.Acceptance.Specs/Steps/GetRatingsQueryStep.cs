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
    public class GetRatingsQueryStep : NancyRequestWrapper
    {
        private BrowserResponse _response;


        [When(@"getting ratings for my account and query parameters")]
        public void WhenGettingRatingForMyAccountAndQueryParameters()
        {
            var accountKey = FeatureContext.Current["AccountKey2"];

            _response = Browser.Get(string.Format("/{0}/Ratings/Query", accountKey), with =>
            {
                with.HttpRequest();
               // with.Query("minRating", "2");
                with.Query("maxRating", "100");
                //with.Query("customParams", "videoId:1234,otherField:otherFieldValue");
            }); 
        }


        [Then(@"I should be able to see all my ratings for my query")]
        public void ThenIShouldBeAbleToSeeAllMyRatingsForMyQuery()
        {
            /*
            var responseString = _response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<List<Dictionary<string, object>>>(responseString);

            
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);*/
        }
    }
}
