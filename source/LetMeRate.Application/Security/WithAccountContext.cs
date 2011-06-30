using System;

namespace LetMeRate.Application.Security
{
    public abstract class WithAccountContext
    {
        private readonly AccountContext _accountContext;

        protected WithAccountContext(AccountContext accountContext)
        {
            if (accountContext == null) throw new ArgumentNullException("accountContext", "Account context cannot be null.");
            _accountContext = accountContext;
        }

        public AccountContext AccountContext
        {
            get { return _accountContext; }
        }
    }
}
