using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Web.Acceptance.Specs.Setup;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Steps
{
    [Binding]
    public class VerifyAccountStep : NancyRequestWrapper
    {
        private BrowserResponse _response;

        [When(@"sending my validation key")]
        public void WhenSendingMyValidationKey()
        {
            var validationKey = FeatureContext.Current["AccountKey2"];

            _response = Browser.Post(string.Format("/Account/Validate"), with =>
                                                                             {
                                                                                 with.HttpRequest();
                                                                                 with.FormValue("ValidationKey", (string)validationKey);
                                                                             });
        }

        [Then(@"I should see a result that I am validated")]
        public void ThenIShouldSeeAResultThatIAmValidated()
        {
            Assert.AreEqual("1", _response.GetBodyAsString());
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }



        [When(@"sending my validation key that is invalid")]
        public void WhenSendingMyValidationKeyThatIsInvalid()
        {
            var validationKey = "I've made something up";

            _response = Browser.Post(string.Format("/Account/Validate"), with =>
            {
                with.HttpRequest();
                with.FormValue("ValidationKey", (string)validationKey);
            });
        }

        [Then(@"I should see a result that I am not validated")]
        public void ThenIShouldSeeAResultThatIAmNotValidated()
        {
            Assert.AreEqual("0", _response.GetBodyAsString());
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }

    }
}
