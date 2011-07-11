using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetRatingUniqueKeyQuery : WithAccountContext
    {
        private readonly string _uniqueKey;

        public GetRatingUniqueKeyQuery(AccountContext accountContext, string uniqueKey) : base(accountContext)
        {
            _uniqueKey = uniqueKey;
        }

        public string UniqueKey
        {
            get { return _uniqueKey; }
        }
    }
}
