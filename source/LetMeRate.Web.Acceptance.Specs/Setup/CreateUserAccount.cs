using System.Collections.Generic;
using Nancy.Json;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Setup
{
    [Binding]
    public class CreateUserAccount
    {
        [BeforeScenario]
        public void CreateAUserAccount()
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
    }
}
