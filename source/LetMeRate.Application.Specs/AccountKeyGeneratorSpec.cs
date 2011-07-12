using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;
using Machine.Specifications;

namespace LetMeRate.Application.Specs
{
    [Subject("When generating an account key")]
    public class AccountKeyGeneratorSpec
    {
        private Establish context = () =>
                                        {
                                            accountKeyGenerator = new AccountKeyGenerator();
                                        };


        private Because of = () =>
                                 {
                                     key = accountKeyGenerator.CreateKey();
                                     key2 = accountKeyGenerator.CreateKey();
                                 };

        private It should_have_created_a_key = () =>
                                                   {
                                                       key.ShouldNotBeEmpty();
                                                       key.ShouldNotBeNull();
                                                       key.ShouldNotEqual(key2);
                                                   };


        private static AccountKeyGenerator accountKeyGenerator;
        private static string key;
        private static string key2;
    }
}
