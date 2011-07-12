using LetMeRate.Web.Acceptance.Specs.Setup;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Steps
{
    [Binding]
    public class AddRatingStep : NancyRequestWrapper
    {
        private BrowserResponse _response;
        private int uniqueKey;

        [When(@"adding a rating for my account")]
        public void WhenAddingARatingForMyAccount()
        {
            var accountKey = FeatureContext.Current["AccountKey"];
            uniqueKey = 1;

            _response = Browser.Post(string.Format("/{0}/Ratings", accountKey), with =>
            {
                with.HttpRequest();
                with.FormValue("Rating", "10");
                with.FormValue("UniqueKey", uniqueKey.ToString());
                with.FormValue("CustomParams", "{ \"RelatedContent\": \"1234\" }");
            }); 
        }

        [Then(@"I should be able to see the rating i added")]
        public void ThenIShouldBeAbleToSeeTheRatingIAdded()
        {
            Assert.AreEqual("\"1\"", _response.GetBodyAsString());
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}
