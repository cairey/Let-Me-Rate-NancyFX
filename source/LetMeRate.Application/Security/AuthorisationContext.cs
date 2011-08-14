using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LetMeRate.Application.Security
{
    public class AuthorisationContext
    {
        private readonly string tokenKey;
        private readonly IPAddress ipAddress;

        public AuthorisationContext(string tokenKey, IPAddress ipAddress)
        {
            this.tokenKey = tokenKey;
            this.ipAddress = ipAddress;
        }

        public IPAddress IpAddress
        {
            get { return ipAddress; }
        }

        public string TokenKey
        {
            get { return tokenKey; }
        }
    }
}
