using System;
using System.Collections.Generic;
using System.Web;
using LetMeRate.Common;
using LetMeRate.Web.Helpers;
using Nancy.Json;
using Nancy.Testing;
using NSubstitute;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Setup
{
    [Binding]
    public class BeforeScenarios
    {
        [BeforeScenario]
        public void GeneralSetup()
        {
            var httpContextWrapper = Substitute.For<HttpContextBase>();
            var httpRequestWrapper = Substitute.For<HttpRequestBase>();

            var baseUrl = new Uri("http://baseurl/fearfactory");
            httpRequestWrapper.Url.Returns(baseUrl);
            httpRequestWrapper.UserHostAddress.Returns("192.168.129.189");

            httpContextWrapper.Request.Returns(httpRequestWrapper);
            httpContextWrapper.Request.Returns(httpRequestWrapper);

            DirtyNancyTestingHttpContext.Current = httpContextWrapper;
        }

        [BeforeScenario]
        public void CreateUserAccounts()
        {
            var browser = new Browser(new TestWebBootstrapper());

            // 1
            var response = browser.Post("/Account/Create", with =>
            {
                with.HttpRequest();
                with.FormValue("EmailAddress", "example@example.com");
                with.FormValue("Password", "Pa55word");
                with.FormValue("RateOutOf", "100");
            });

            var responseString = response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["AccountKey"] = result["AccountKey"];


            // 2
            response = browser.Post("/Account/Create", with =>
            {
                with.HttpRequest();
                with.FormValue("EmailAddress", "example2@example.com");
                with.FormValue("Password", "Pa55word2");
                with.FormValue("RateOutOf", "10");
            });

            responseString = response.GetBodyAsString();
            jss = new JavaScriptSerializer();
            result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["AccountKey2"] = result["AccountKey"];

            // 3
            response = browser.Post("/Account/Create", with =>
            {
                with.HttpRequest();
                with.FormValue("EmailAddress", "example3@example.com");
                with.FormValue("Password", "Pa55word3");
                with.FormValue("RateOutOf", "77");
            });

            responseString = response.GetBodyAsString();
            jss = new JavaScriptSerializer();
            result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["AccountKey3"] = result["AccountKey"];
        }

        [BeforeScenario]
        public void CreateTempAuthorisation()
        {
            var browser = new Browser(new TestWebBootstrapper());

            // 1
            var accountKey = FeatureContext.Current["AccountKey"];
            var response = browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.189");
            });

            var responseString = response.GetBodyAsString();
            var jss = new JavaScriptSerializer();
            var result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["TokenKey"] = result["TokenKey"];

            // 2
            accountKey = FeatureContext.Current["AccountKey2"];
            response = browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.189");
            });

            responseString = response.GetBodyAsString();
            jss = new JavaScriptSerializer();
            result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["TokenKey2"] = result["TokenKey"];


            // 3
            accountKey = FeatureContext.Current["AccountKey2"];
            response = browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.189");
            });

            responseString = response.GetBodyAsString();
            jss = new JavaScriptSerializer();
            result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["TokenKey3"] = result["TokenKey"];

            // 4
            accountKey = FeatureContext.Current["AccountKey2"];
            response = browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.189");
            });

            responseString = response.GetBodyAsString();
            jss = new JavaScriptSerializer();
            result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["TokenKey4"] = result["TokenKey"];

            // 5
            accountKey = FeatureContext.Current["AccountKey2"];
            response = browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.189");
            });

            responseString = response.GetBodyAsString();
            jss = new JavaScriptSerializer();
            result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["TokenKey5"] = result["TokenKey"];

            // 6
            accountKey = FeatureContext.Current["AccountKey3"];
            response = browser.Post(string.Format("/{0}/Authorisation", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("IPAddress", "192.168.129.189");
            });

            responseString = response.GetBodyAsString();
            jss = new JavaScriptSerializer();
            result = jss.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current["TokenKey6"] = result["TokenKey"];
        }


        [BeforeScenario]
        public void AddRatings()
        {
            var browser = new Browser(new TestWebBootstrapper());

            // 1
            browser.Post(string.Format("/{0}/Ratings", FeatureContext.Current["TokenKey"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "50");
                with.FormValue("UniqueKey", "1");
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"1012\" }");
            });


            // 2
            browser.Post(string.Format("/{0}/Ratings", FeatureContext.Current["TokenKey2"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "6");
                with.FormValue("UniqueKey", "2");
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"1234\" }");
            });


            // 3
            browser.Post(string.Format("/{0}/Ratings", FeatureContext.Current["TokenKey3"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "7");
                with.FormValue("UniqueKey", "3");
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"1245\" }");
            });


            browser.Post(string.Format("/{0}/Ratings", FeatureContext.Current["TokenKey4"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "2");
                with.FormValue("UniqueKey", "3");
                with.FormValue("CustomParams", "{ \"UserId\": \"1245444\" }");
            });


            browser.Post(string.Format("/{0}/Ratings", FeatureContext.Current["TokenKey5"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "10");
                with.FormValue("UniqueKey", "3");
                with.FormValue("CustomParams", "{ \"UserId\": \"65656756\" }");
            });


            // 4
            browser.Post(string.Format("/{0}/Ratings", FeatureContext.Current["TokenKey6"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "44");
                with.FormValue("UniqueKey", "4");
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"1337\" }");
            });
        }
    }
}
