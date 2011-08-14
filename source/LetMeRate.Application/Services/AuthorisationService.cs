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

        public dynamic GetAuthorsation(GetAuthorisationQuery query)
        {
            var db = Database.Open();
            var authorisation = db.Authorisations.FindAllByTokenKey(query.AuthorisationContext.TokenKey).FirstOrDefault();

            if (authorisation == null)
                throw new Exception("The authorisation token cannot be found with that token key.");

            if (authorisation.IPAddress != query.AuthorisationContext.IpAddress.ToString())
                throw new Exception("The IP Address is not authorised");

            if (authorisation.TokenExpiry <= DateTime.Now)
                throw new Exception("The authorisation token has expired.");

            db.Authorisations.DeleteById(authorisation.Id);

            return authorisation;
        }

        private dynamic GetUserAccount(string accountKey)
        {
            return accountService.GetUserAccountByKey(new GetUserAccountByKeyQuery(new AccountContext(accountKey)));
        }
    }
}
