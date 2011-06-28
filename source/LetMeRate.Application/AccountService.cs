using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace LetMeRate.Application
{
    public class AccountService : IAccountService
    {


        public void CreateAccount(string email, string password)
        {
            var db = Database.Open();
            var customer = db.UserAccount.Insert(Email: email, Password: password);
        }
    }
}
