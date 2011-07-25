using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Web.Acceptance.Specs.Setup;
using Nancy.Testing;
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
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see a result that I am validated")]
        public void ThenIShouldSeeAResultThatIAmValidated()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
