using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Application.Security
{
    public class AccountContext
    {
        private readonly string accountKey;

        public AccountContext(string accountKey)
        {
            this.accountKey = accountKey;
            if (string.IsNullOrWhiteSpace(accountKey)) throw new ArgumentException("The account key is not valid.", "accountKey");
        }

        public string AccountKey
        {
            get { return accountKey; }
        }
    }
}
