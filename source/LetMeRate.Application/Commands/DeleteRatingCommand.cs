using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Commands
{
    public class DeleteRatingCommand
    {
        private readonly AccountContext _accountContext;
        private readonly string _uniqueKey;

        public DeleteRatingCommand(AccountContext accountContext, string uniqueKey)
        {
            _accountContext = accountContext;
            _uniqueKey = uniqueKey;
        }

        public string UniqueKey
        {
            get { return _uniqueKey; }
        }

        public AccountContext AccountContext
        {
            get { return _accountContext; }
        }
    }
}
