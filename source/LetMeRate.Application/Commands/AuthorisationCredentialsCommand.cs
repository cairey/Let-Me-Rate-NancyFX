using System.Net;
using LetMeRate.Application.Security;

namespace LetMeRate.Application.Commands
{
    public class AuthorisationCredentialsCommand : WithAccountContext
    {
        private readonly IPAddress ipAddress;

        public AuthorisationCredentialsCommand(AccountContext accountContext, IPAddress ipAddress)
            : base(accountContext)
        {
            this.ipAddress = ipAddress;
        }

        public IPAddress IpAddress
        {
            get { return ipAddress; }
        }
    }
}