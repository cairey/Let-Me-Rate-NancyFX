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
    public class DeleteRatingStep : NancyRequestWrapper
    {
        private BrowserResponse _response;

        [When(@"I delete a rating with a known unique key")]
        public void WhenIDeleteARatingWithAKnownUniqueKey()
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
            var uniqueKey = 3;

            _response = Browser.Delete(string.Format("/{0}/Ratings/{1}", tokenKey, uniqueKey), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "10");
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"1234\" }");
            });
        }


        [When(@"I delete a rating that does not exist")]
        public void WhenIDeleteARatingThatDoesNotExist()
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
            var uniqueKey = 9;

            _response = Browser.Delete(string.Format("/{0}/Ratings/{1}", tokenKey, uniqueKey), with =>
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


        [Then(@"my rating should not have been found")]
        public void ThenMyRatingShouldNotHaveBeenFound()
        {
            Assert.AreEqual("0", _response.GetBodyAsString());
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
