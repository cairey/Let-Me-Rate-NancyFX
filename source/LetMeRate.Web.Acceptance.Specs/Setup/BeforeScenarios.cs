using System.Collections.Generic;
using Nancy.Json;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Setup
{
    [Binding]
    public class BeforeScenarios
    {
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
        public void AddRatings()
        {
            var browser = new Browser(new TestWebBootstrapper());

            // 1
            browser.Post(string.Format("/{0}/Rate", FeatureContext.Current["AccountKey"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "50");
                //with.FormValue("CustomParams", "{ \"VideoId\": \"1234\" }");
                with.FormValue("CustomParams", "1234");
            });


            // 2
            browser.Post(string.Format("/{0}/Rate", FeatureContext.Current["AccountKey2"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "6");
                //with.FormValue("CustomParams", "{ \"VideoId\": \"1234\" }");
                with.FormValue("CustomParams", "0666");
            });


            // 3
            browser.Post(string.Format("/{0}/Rate", FeatureContext.Current["AccountKey2"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "7");
                //with.FormValue("CustomParams", "{ \"VideoId\": \"1234\" }");
                with.FormValue("CustomParams", "0664");
            });


            // 4
            browser.Post(string.Format("/{0}/Rate", FeatureContext.Current["AccountKey3"]), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "44");
                //with.FormValue("CustomParams", "{ \"VideoId\": \"1234\" }");
                with.FormValue("CustomParams", "7777");
            });
        }
    }
}
