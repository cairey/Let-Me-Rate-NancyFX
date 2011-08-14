using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Application.Security
{
    public abstract class WithAuthorisationContext
    {
        private readonly AuthorisationContext authorisationContext;

        protected WithAuthorisationContext(AuthorisationContext authorisationContext)
        {
            if (authorisationContext == null) throw new ArgumentNullException("authorisationContext", "AuthorisationContext context cannot be null.");
            this.authorisationContext = authorisationContext;
        }

        public AuthorisationContext AuthorisationContext
        {
            get { return authorisationContext; }
        }
    }
}
