using System.Collections.Generic;
using Nancy.Json;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Setup
{
    [Binding]
    public class CreateAccount
    {
        [BeforeScenario]
        public void CreateUserAccount()
        {
            var browser = new Browser(new TestWebBootstrapper());
            var response = browser.Post("/Account/Create", with =>
            {
                with.HttpRequest();
                with.FormValue("EmailAddress", "example@example.com");
                with.FormValue("Password", "Pa55word");
                with.FormValue("RateOutOf", "100");
            });

            var responseString = response.GetBodyAsString();
            JavaScriptSerializer s = new JavaScriptSerializer();
            var res = s.Deserialize<Dictionary<string, object>>(responseString);
            FeatureContext.Current.Add("AccountKey", res["AccountKey"]);
        }
    }
}
