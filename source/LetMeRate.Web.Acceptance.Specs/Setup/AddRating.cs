using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Json;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Setup
{
    [Binding]
    public class AddRating
    {
        [BeforeScenario]
        public void AddARating()
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
