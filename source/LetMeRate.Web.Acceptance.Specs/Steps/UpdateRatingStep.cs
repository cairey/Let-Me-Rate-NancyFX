using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Web.Acceptance.Specs.Setup;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Steps
{
    [Binding]
    public class UpdateRatingStep : NancyRequestWrapper
    {
        private BrowserResponse _response;

        [When(@"I update my rating that exists")]
        public void WhenIUpdateMyRatingThatExists()
        {
            var accountKey = FeatureContext.Current["AccountKey2"];
            var uniqueKey = 3;

            _response = Browser.Put(string.Format("/{0}/Ratings/{1}", accountKey, uniqueKey), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "3");
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"6757\" }");
            });
        }

        [Then(@"my rating should be updated")]
        public void ThenMyRatingShouldBeUpdated()
        {
            Assert.AreEqual("1", _response.GetBodyAsString());
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }


        [When(@"I update my rating that does not exists")]
        public void WhenIUpdateMyRatingThatDoesNotExists()
        {
            var accountKey = FeatureContext.Current["AccountKey2"];
            var uniqueKey = 9;

            _response = Browser.Put(string.Format("/{0}/Ratings/{1}", accountKey, uniqueKey), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "3");
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"6757\" }");
            });
        }


        [Then(@"my rating should not be updated")]
        public void ThenMyRatingShouldNotBeUpdated()
        {
            Assert.AreEqual("0", _response.GetBodyAsString());
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
