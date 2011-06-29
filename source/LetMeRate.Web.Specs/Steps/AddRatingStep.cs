﻿using NUnit.Framework;
using Nancy;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Steps
{
    [Binding]
    public class AddRatingStep
    {
        private Browser _browser;
        private BrowserResponse _response;

        [Given(@"I am using Ratings")]
        public void GivenIAmUsingRatings()
        {
            _browser = new Browser(new TestWebBootstrapper());
        }

        [When(@"adding a rating for my account")]
        public void WhenAddingARatingForMyAccount()
        {
            var accountKey = FeatureContext.Current["AccountKey"];

            _response = _browser.Post(string.Format("/{0}/Rate", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "10");
                with.FormValue("CustomParams", "{'MyVideoId': '1234'}");
            }); 
        }

        [Then(@"I should be able to see the rating i added")]
        public void ThenIShouldBeAbleToSeeTheRatingIAdded()
        {
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}