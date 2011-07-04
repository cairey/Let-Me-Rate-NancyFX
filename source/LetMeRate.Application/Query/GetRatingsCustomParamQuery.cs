using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetRatingsCustomParamQuery : WithAccountContext
    {
        private readonly string _customParam;
        private readonly string _customQuery;

        public GetRatingsCustomParamQuery(AccountContext accountContext, string customParam, string customQuery) : base(accountContext)
        {
            _customParam = customParam;
            _customQuery = customQuery;
        }

        public string CustomQuery
        {
            get { return _customQuery; }
        }

        public string CustomParam
        {
            get { return _customParam; }
        }
    }
}
