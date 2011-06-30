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
    public class SecurityDigestStep
    {
        private SecurityDigest _securityDigest;
        private string _plainTextPhase;
        private string _hashedPhase;
        private string _salt;
        private bool _authenticated;

        [Given(@"I have supplied a phase")]
        public void GivenIHaveSuppliedAPhase()
        {
            _securityDigest = new SecurityDigest();
            _plainTextPhase = "pa55word";
        }

        [Given(@"I have generated a salt")]
        public void GivenIHaveGeneratedASalt()
        {
            _salt = _securityDigest.CreateSalt();
            _hashedPhase = _securityDigest.EncryptPhase(_plainTextPhase, _salt);
        }

        [When(@"verifying the hashed phases with a correct phase")]
        public void WhenVerifyingTheHashedPhasesWithACorrectPhase()
        {
            _authenticated = _securityDigest.Authenticated("pa55word", _hashedPhase, _salt);
        }

        [Then(@"the result should be a match")]
        public void ThenTheResultShouldBeAMatch()
        {
            Assert.IsTrue(_authenticated);
        }

        [When(@"verifying the hashed phases with an incorrect phase")]
        public void WhenVerifyingTheHashedPhasesWithAnIncorrectPhase()
        {
            _authenticated = _securityDigest.Authenticated("password", _hashedPhase, _salt);
        }

        [Then(@"the result should not be a match")]
        public void ThenTheResultShouldNotBeAMatch()
        {
            Assert.IsFalse(_authenticated);
        }
    }
}
