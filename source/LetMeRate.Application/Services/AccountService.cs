using System;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;
using LetMeRate.Application.Security;
using Simple.Data;

namespace LetMeRate.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountKeyGenerator accountKeyGenerator;
        private readonly ISecurityDigest securityDigest;

        public AccountService(IAccountKeyGenerator accountKeyGenerator, ISecurityDigest securityDigest)
        {
            this.accountKeyGenerator = accountKeyGenerator;
            this.securityDigest = securityDigest;
        }

        public dynamic CreateAccount(AddUserAccountCommand command)
        {
            var accountKey = accountKeyGenerator.CreateKey();
            var passwordSalt = securityDigest.CreateSalt();
            var encPassword = securityDigest.EncryptPhase(command.Password, passwordSalt);
            var email = command.Email;
            var rateOutOf = command.RateOutOf;

            var db = Database.Open();
            db.UserAccounts.Insert(Id : Guid.NewGuid(),
                                                    Email: email, 
                                                    Password: encPassword,
                                                    PasswordSalt: passwordSalt, 
                                                    Key: accountKey,
                                                    RateOutOf: (int)rateOutOf);

            return GetUserAccountByKey(new GetUserAccountByKeyQuery(new AccountContext(accountKey)));
        }


        public dynamic GetUserAccountByKey(GetUserAccountByKeyQuery query)
        {
            var db = Database.Open();
            var userAccount = db.UserAccounts.FindAllByKey(query.AccountContext.AccountKey).SingleOrDefault();

            if (userAccount == null) throw new Exception("The user account cannot be found with that key.");
            return userAccount;
        }


        public dynamic GetUserAccount(GetUserAccountQuery query)
        {
            var db = Database.Open();
            var userAccount = db.UserAccounts.FindAllById(query.UserAccountId).SingleOrDefault();

            if (userAccount == null) throw new Exception("The user account cannot be found with that key.");
            return userAccount;
        }

        public dynamic ValidateAccount(ValidateAccountCommand command)
        {
            var db = Database.Open();
            var userAccount = db.UserAccounts.FindAllByKey(command.ValidationKey).SingleOrDefault();
            if (userAccount == null) return 0;
            userAccount.Enabled = true;
            return db.UserAccounts.Update(userAccount); ;
        }
    }
}
