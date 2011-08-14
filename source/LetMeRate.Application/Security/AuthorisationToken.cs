using System;
using System.Net;

namespace LetMeRate.Application.Security
{
    public class AuthorisationToken
    {
        private readonly IPAddress ipAddress;
        private readonly DateTime expiry;
        private readonly string tokenKey;

        public AuthorisationToken(IPAddress ipAddress)
        {
            this.ipAddress = ipAddress;
            expiry = DateTime.Now.AddMinutes(5);
            tokenKey = Guid.NewGuid().ToString();
        }

        public IPAddress IPAddress
        {
            get { return ipAddress; }
        }

        public string TokenKey
        {
            get { return tokenKey; }
        }

        public DateTime Expiry
        {
            get { return expiry; }
        }
    }
}