using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Application
{
    public interface IAccountService
    {
        void CreateAccount(string email, string password);
    }
}
