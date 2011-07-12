using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Web.Acceptance.Specs.Setup;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Steps
{
    [Binding]
    public class DeleteRatingStep : NancyRequestWrapper
    {
        private BrowserResponse _response;

        [When(@"I delete ratings")]
        public void WhenIDeleteRatings()
        {
            var accountKey = FeatureContext.Current["AccountKey2"];
            var uniqueKey = 3;

            _response = Browser.Delete(string.Format("/{0}/Ratings/{1}", accountKey, uniqueKey), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "10");
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"1234\" }");
            });
        }

        [Then(@"my rating should have been deleted")]
        public void ThenMyRatingShouldHaveBeenDeleted()
        {
            Assert.AreEqual("1", _response.GetBodyAsString());
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
