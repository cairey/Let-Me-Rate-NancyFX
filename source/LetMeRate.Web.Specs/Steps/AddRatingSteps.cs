using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Specs.Steps
{
    [Binding]
    public class AddRatingStep
    {
        [Given(@"I am using Ratings")]
        public void GivenIAmUsingRatings()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"adding a rating for my account")]
        public void WhenAddingARatingForMyAccount()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to add my rating based on the score system for my account")]
        public void ThenIShouldBeAbleToAddMyRatingBasedOnTheScoreSystemForMyAccount()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to see the rating i added")]
        public void ThenIShouldBeAbleToSeeTheRatingIAdded()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
