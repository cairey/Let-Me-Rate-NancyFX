using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetRatingUniqueKeyQuery : WithAuthorisationContext
    {
        private readonly string uniqueKey;

        public GetRatingUniqueKeyQuery(AuthorisationContext authorisationContext, string uniqueKey)
            : base(authorisationContext)
        {
            this.uniqueKey = uniqueKey;
        }

        public string UniqueKey
        {
            get { return uniqueKey; }
        }
    }
}
