using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Application.Query
{
    public class GetRatingsQuery
    {
        private readonly string _accountKey;

        public GetRatingsQuery(string accountKey)
        {
            _accountKey = accountKey;
        }

        public string AccountKey
        {
            get { return _accountKey; }
        }
    }
}
