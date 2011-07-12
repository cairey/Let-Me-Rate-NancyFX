using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;
using Machine.Specifications;

namespace LetMeRate.Application.Specs
{
    [Subject("When I want to be authenticated")]
    public class when_I_want_to_be_authenticated
    {
        private Establish context = () =>
        {
            _securityDigest = new SecurityDigest();
            _plainTextPhase = "pa55word";
            _salt = _securityDigest.CreateSalt();
            _hashedPhase = _securityDigest.EncryptPhase(_plainTextPhase, _salt);
        };

        private Because of = () =>
                                 {
                                     _authenticated = _securityDigest.Authenticated("pa55word", _hashedPhase, _salt);
                                 };

        private It should_be_a_match = () => _authenticated.ShouldBeTrue();



        private static string _plainTextPhase;
        private static SecurityDigest _securityDigest;
        private static string _salt;
        private static string _hashedPhase;
        private static bool _authenticated;
    }


    [Subject("When I don't want to be authenticated")]
    public class when_I_dont_want_to_be_authenticated
    {
        private Establish context = () =>
        {
            _securityDigest = new SecurityDigest();
            _plainTextPhase = "pa55word";
            _salt = _securityDigest.CreateSalt();
            _hashedPhase = _securityDigest.EncryptPhase(_plainTextPhase, _salt);
        };

        private Because of = () =>
        {
            _authenticated = _securityDigest.Authenticated("password", _hashedPhase, _salt);
        };

        private It should_be_a_match = () => _authenticated.ShouldBeFalse();


        private static string _plainTextPhase;
        private static SecurityDigest _securityDigest;
        private static string _salt;
        private static string _hashedPhase;
        private static bool _authenticated;
    }
}
