using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace LetMeRate.Web.Acceptance.Specs.Setup
{
    [Binding]
    public class NancyRequest
    {
        [Given(@"I am making web request")]
        public void GivenIAmMakingWebRequest()
        {
            FeatureContext.Current["Bowser"] = new Browser(new TestWebBootstrapper());
        }
    }
 
    public abstract class NancyRequestWrapper
    {
        public Browser Browser { get { return (Browser)FeatureContext.Current["Bowser"]; } }
    }
}
