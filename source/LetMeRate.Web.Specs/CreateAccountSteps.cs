using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Specs
{
    [Binding]
    public class StepDefinitions
    {
        [Given(@"I am creating an account")]
        public void GivenIAmCreatingAnAccount()
        {
            var accountModule = new AccountModule();


            ScenarioContext.Current.Pending();
        }

        [When(@"adding details")]
        public void WhenAddingDetails()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"I should be able to add my email address")]
        public void ThenIShouldBeAbleToAddMyEmailAddress()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"I should be able to add my password")]
        public void ThenIShouldBeAbleToAddMyPassword()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
