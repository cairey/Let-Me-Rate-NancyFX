using System;

namespace LetMeRate.Application.Security
{
    public class KeyGenerator : IAccountKeyGenerator
    {
        public string CreateKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}