using System;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
using LetMeRate.Application.Security;
using Simple.Data;

namespace LetMeRate.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountKeyGenerator _accountKeyGenerator;
        private readonly ISecurityDigest _securityDigest;

        public AccountService(IAccountKeyGenerator accountKeyGenerator, ISecurityDigest securityDigest)
        {
            _accountKeyGenerator = accountKeyGenerator;
            _securityDigest = securityDigest;
        }

        public dynamic CreateAccount(AddUserAccountCommand addUserAccountCommand)
        {
            var accountKey = _accountKeyGenerator.CreateKey();
            var passwordSalt = _securityDigest.CreateSalt();
            var encPassword = _securityDigest.EncryptPhase(addUserAccountCommand.Password, passwordSalt);
            var email = addUserAccountCommand.Email;
            var rateOutOf = addUserAccountCommand.RateOutOf;

            var db = Database.Open();
            db.UserAccounts.Insert(Id : Guid.NewGuid(),
                                                    Email: email, 
                                                    Password: encPassword,
                                                    PasswordSalt: passwordSalt, 
                                                    Key: accountKey,
                                                    RateOutOf: (int)rateOutOf);

            return GetUserAccountByKey(new GetAccountQuery(new AccountContext(accountKey)));
        }


        public dynamic GetUserAccountByKey(GetAccountQuery getAccountQuery)
        {
            var db = Database.Open();
            var userAccount = db.UserAccounts.FindAllByKey(getAccountQuery.AccountContext.AccountKey).FirstOrDefault();

            if (userAccount == null) throw new Exception("The user account cannot be found with that key.");
            return userAccount;
        }

        public dynamic ValidateAccount(ValidateAccountCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
