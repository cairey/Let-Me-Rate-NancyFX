using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
using LetMeRate.Application.Security;
using Simple.Data;

namespace LetMeRate.Application.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        private readonly IAccountService accountService;

        public AuthorisationService(IAccountService accountService)
        {
            this.accountService = accountService;
        }


        public dynamic CreateAuthorisationToken(AuthorisationCredentialsCommand command)
        {
            var userAccount = GetUserAccount(command.AccountContext.AccountKey);
            var authToken = new AuthorisationToken(command.IpAddress);

            dynamic authorisation = new ExpandoObject();
            authorisation.Id = Guid.NewGuid();
            authorisation.UserAccountId = userAccount.Id;
            authorisation.IPAddress = authToken.IPAddress;
            authorisation.TokenExpiry = authToken.Expiry;
            authorisation.TokenKey = authToken.TokenKey;

            var db = Database.Open();
            db.Authorisations.Insert(authorisation);
            return authorisation;
        }

        private dynamic GetUserAccount(string accountKey)
        {
            return accountService.GetUserAccountByKey(new GetAccountQuery(new AccountContext(accountKey)));
        }
    }
}
