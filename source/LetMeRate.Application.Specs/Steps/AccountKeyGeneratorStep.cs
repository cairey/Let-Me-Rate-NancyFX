using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LetMeRate.Application.Specs.Steps
{
    [Binding]
    public class AccountKeyGeneratorStep
    {
        private AccountKeyGenerator _accountKeygenerator;
        private string _accountKey1;
        private string _accountKey2;

        [Given(@"I have an account key generator")]
        public void GivenIHaveAnAccountKeyGenerator()
        {
             _accountKeygenerator = new AccountKeyGenerator();
        }

        [When(@"I generate an account key")]
        public void WhenIGenerateAnAccountKey()
        {
            _accountKey1 = _accountKeygenerator.CreateKey();
            _accountKey2 = _accountKeygenerator.CreateKey();
        }

        [Then(@"I should get back a unique key")]
        public void ThenIShouldGetBackAUniqueKey()
        {
            Assert.IsNotNullOrEmpty(_accountKey1);
            Assert.IsNotNullOrEmpty(_accountKey2);
            Assert.AreNotEqual(_accountKey1, _accountKey2);
        }
    }
}
