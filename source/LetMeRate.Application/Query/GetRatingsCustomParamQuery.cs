using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetRatingsCustomParamQuery : WithAuthorisationContext
    {
        private readonly string customParam;
        private readonly string customQuery;

        public GetRatingsCustomParamQuery(AuthorisationContext authorisationContext, string customParam, string customQuery)
            : base(authorisationContext)
        {
            this.customParam = customParam;
            this.customQuery = customQuery;
        }

        public string CustomQuery
        {
            get { return customQuery; }
        }

        public string CustomParam
        {
            get { return customParam; }
        }
    }
}
