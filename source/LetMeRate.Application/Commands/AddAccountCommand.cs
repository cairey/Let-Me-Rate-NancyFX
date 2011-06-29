using System;
using System.Text.RegularExpressions;

namespace LetMeRate.Application.Commands
{
    public class AddAccountCommand
    {
        private readonly string _email;
        private readonly string _password;
        private readonly uint _rateOutOf;

        public AddAccountCommand(string email, string password, uint rateOutOf)
        {
            if(string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email Address not supplied.", "email");
            
            Regex emailExp = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            if (!emailExp.IsMatch(email)) throw new ArgumentException("Email Address supplied in not valid email.", "email");
            
            if(string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password not supplied.", "password");
            
            if (rateOutOf <= 0) throw new ArgumentException("Rate Out Of cannot be less than or equal to zero.", "rateOutOf");

            _email = email;
            _password = password;
            _rateOutOf = rateOutOf;
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
