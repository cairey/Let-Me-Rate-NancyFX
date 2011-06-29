using System;
using LetMeRate.Application.Commands;
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
            var key = _accountKeyGenerator.CreateKey();
            var passwordSalt = _securityDigest.CreateSalt();
            var encPassword = _securityDigest.EncryptPhase(addUserAccountCommand.Password, passwordSalt);
            var email = addUserAccountCommand.Email;
            var rateOutOf = addUserAccountCommand.RateOutOf;

            var db = Database.Open();
            db.UserAccount.Insert(Id : Guid.NewGuid(),
                                                    Email: email, 
                                                    Password: encPassword,
                                                    PasswordSalt: passwordSalt, 
                                                    Key: key,
                                                    RateOutOf: (int)rateOutOf);

            return GetUserAccountByKey(key);
        }


        public dynamic GetUserAccountByKey(string accountKey)
        {
            var db = Database.Open();
            var userAccount = db.UserAccount.FindAllByKey(accountKey).FirstOrDefault();

            if (userAccount == null) throw new Exception("The user account cannot be found with that key.");
            return userAccount;
        }
    }
}
