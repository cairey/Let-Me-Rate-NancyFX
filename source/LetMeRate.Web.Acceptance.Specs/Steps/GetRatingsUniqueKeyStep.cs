﻿using System;
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
    public class GetRatingsUniqueKeyStep : NancyRequestWrapper
    {
        private BrowserResponse _response;
        private int _uniqueKey;

        [When(@"getting ratings for my account and unique key")]
        public void WhenGettingRatingsForMyAccountAndUniqueKey()
        {
            var accountKey = FeatureContext.Current["AccountKey"];
            _uniqueKey = 1;

            _response = Browser.Get(string.Format("/{0}/Ratings/Key/{1}", accountKey, _uniqueKey), with =>
            {
                with.HttpRequest();
            }); 
        }

        [Then(@"I should be able to see my rating for my key")]
        public void ThenIShouldBeAbleToSeeMyRatingForMyKey()
        {
            var responseString = _response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<List<Dictionary<string, object>>>(responseString);

            Assert.IsNotEmpty(responseString);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
