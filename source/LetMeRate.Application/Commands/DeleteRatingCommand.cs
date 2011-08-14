using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Commands
{
    public class DeleteRatingCommand : WithAuthorisationContext
    {
        private readonly string uniqueKey;

        public DeleteRatingCommand(AuthorisationContext authorisationContext, string uniqueKey)
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
