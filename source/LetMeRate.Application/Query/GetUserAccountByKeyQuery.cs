﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Query
{
    public class GetUserAccountByKeyQuery : WithAccountContext
    {
        public GetUserAccountByKeyQuery(AccountContext accountContext)
            : base(accountContext)
        {
        }

    }
}
