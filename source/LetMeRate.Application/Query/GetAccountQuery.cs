using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Application.Query
{
    public class GetAccountQuery
    {
        private readonly string _accountKey;

        public GetAccountQuery(string accountKey)
        {
            _accountKey = accountKey;
        }

        public string AccountKey
        {
            get { return _accountKey; }
        }
    }
}
