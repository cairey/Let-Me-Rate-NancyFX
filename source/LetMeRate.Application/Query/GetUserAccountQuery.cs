using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Application.Query
{
    public class GetUserAccountQuery
    {
        private readonly Guid userAccountId;

        public GetUserAccountQuery(Guid userAccountId)
        {
            this.userAccountId = userAccountId;
        }

        public Guid UserAccountId
        {
            get { return userAccountId; }
        }
    }
}
