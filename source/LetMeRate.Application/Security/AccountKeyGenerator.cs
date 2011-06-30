using System;

namespace LetMeRate.Application.Security
{
    public class AccountKeyGenerator : IAccountKeyGenerator
    {
        public string CreateKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}