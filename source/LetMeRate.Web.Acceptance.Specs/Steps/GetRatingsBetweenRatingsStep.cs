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
    public class GetRatingsBetweenRatingsStep : NancyRequestWrapper
    {
        private BrowserResponse _response;


        [When(@"getting ratings for my account and between 7 and 10")]
        public void WhenGettingRatingsForMyAccountAndBetween7And10()
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

            _response = Browser.Get(string.Format("/{0}/Ratings/Between/Rating", tokenKey), with =>
            {
                with.HttpRequest();
                with.Query("minRating", "7");
                with.Query("maxRating", "10");
            }); 
        }


        [Then(@"I should be able to see all my ratings for my query")]
        public void ThenIShouldBeAbleToSeeAllMyRatingsForMyQuery()
        {
            var responseString = _response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<List<Dictionary<string, object>>>(responseString);

            Assert.IsNotEmpty(responseString);
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
