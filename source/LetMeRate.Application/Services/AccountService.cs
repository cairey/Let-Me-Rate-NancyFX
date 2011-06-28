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

        public void CreateAccount(string email, string password)
        {
            var key = _accountKeyGenerator.CreateKey();
            var passwordSalt = _securityDigest.CreateSalt();
            var encPassword = _securityDigest.EncryptPhase(password, passwordSalt);


            var db = Database.Open();
            var userAccount = db.UserAccount.Insert(Email: email, 
                                                    Password: encPassword,
                                                    PasswordSalt: passwordSalt, 
                                                    Key: key);
        }
    }
}
