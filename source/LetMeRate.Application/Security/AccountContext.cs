using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Application.Security
{
    public class AccountContext
    {
        private readonly string _accountKey;

        public AccountContext(string accountKey)
        {
            _accountKey = accountKey;
            if (string.IsNullOrWhiteSpace(accountKey)) throw new ArgumentException("The account key is not valid.", "accountKey");
        }

        public string AccountKey
        {
            get { return _accountKey; }
        }
    }
}
