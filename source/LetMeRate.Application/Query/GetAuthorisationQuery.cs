using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetAuthorisationQuery
    {
        private readonly AuthorisationContext authorisationContext;

        public GetAuthorisationQuery(AuthorisationContext authorisationContext)
        {
            this.authorisationContext = authorisationContext;
        }

        public AuthorisationContext AuthorisationContext
        {
            get { return authorisationContext; }
        }
    }
}
