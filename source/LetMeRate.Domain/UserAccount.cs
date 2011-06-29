using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Domain
{
    public class UserAccount
    {
        private readonly string _email;
        private readonly string _password;
        private readonly uint _rateOutOf;

        public UserAccount()
        {
                
        }


        public uint RateOutOf
        {
            get { return _rateOutOf; }
        }

        public string Password
        {
            get { return _password; }
        }

        public string Email
        {
            get { return _email; }
        }
    }
}
