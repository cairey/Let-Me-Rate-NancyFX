﻿using System;
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
    public class GetRatingsStep : NancyRequestWrapper
    {
        private BrowserResponse _response;

        [When(@"getting rating for my account")]
        public void WhenGettingRatingForMyAccount()
        {
            var accountKey = FeatureContext.Current["AccountKey"];

            _response = Browser.Get(string.Format("/{0}/Ratings", accountKey), with =>
            {
                with.HttpRequest();
            }); 
        }

        [Then(@"I should be able to see all my ratings")]
        public void ThenIShouldBeAbleToSeeAllMyRatings()
        {
            ScenarioContext.Current.Pending();

            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
