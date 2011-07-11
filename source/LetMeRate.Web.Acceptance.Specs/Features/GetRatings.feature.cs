// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.6.1.0
//      SpecFlow Generator Version:1.6.0.0
//      Runtime Version:4.0.30319.235
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace LetMeRate.Web.Acceptance.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.6.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Get Ratings")]
    public partial class GetRatingsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetRatings.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Get Ratings", "In order to see Ratings\r\nAs a user of Ratings\r\nI want to be able to see ratings", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting ratings")]
        [NUnit.Framework.CategoryAttribute("CreateUserAccounts")]
        [NUnit.Framework.CategoryAttribute("AddRatings")]
        [NUnit.Framework.CategoryAttribute("ClearDatabase")]
        public virtual void GettingRatings()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting ratings", new string[] {
                        "CreateUserAccounts",
                        "AddRatings",
                        "ClearDatabase"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
testRunner.Given("I am making web request");
#line 12
testRunner.When("getting rating for my account");
#line 13
testRunner.Then("I should be able to see all my ratings");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting ratings between ratings")]
        [NUnit.Framework.CategoryAttribute("CreateUserAccounts")]
        [NUnit.Framework.CategoryAttribute("AddRatings")]
        [NUnit.Framework.CategoryAttribute("ClearDatabase")]
        public virtual void GettingRatingsBetweenRatings()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting ratings between ratings", new string[] {
                        "CreateUserAccounts",
                        "AddRatings",
                        "ClearDatabase"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
testRunner.Given("I am making web request");
#line 22
testRunner.When("getting ratings for my account and between 7 and 10");
#line 23
testRunner.Then("I should be able to see all my ratings for my query");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting ratings for my custom parameter")]
        [NUnit.Framework.CategoryAttribute("CreateUserAccounts")]
        [NUnit.Framework.CategoryAttribute("AddRatings")]
        [NUnit.Framework.CategoryAttribute("ClearDatabase")]
        public virtual void GettingRatingsForMyCustomParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting ratings for my custom parameter", new string[] {
                        "CreateUserAccounts",
                        "AddRatings",
                        "ClearDatabase"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
testRunner.Given("I am making web request");
#line 31
testRunner.When("getting ratings for my account and and my custom parameter");
#line 32
testRunner.Then("I should be able to see all my ratings for my custom query");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get rating by unique key")]
        [NUnit.Framework.CategoryAttribute("CreateUserAccounts")]
        [NUnit.Framework.CategoryAttribute("AddRatings")]
        [NUnit.Framework.CategoryAttribute("ClearDatabase")]
        public virtual void GetRatingByUniqueKey()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get rating by unique key", new string[] {
                        "CreateUserAccounts",
                        "AddRatings",
                        "ClearDatabase"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
testRunner.Given("I am making web request");
#line 40
testRunner.When("getting ratings for my account and unique key");
#line 41
testRunner.Then("I should be able to see my rating for my key");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
