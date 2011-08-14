using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Security;
using LetMeRate.Application.Services;
using Nancy;

namespace LetMeRate.Web
{
    public class AuthorisationModule : LetMeRateModule
    {
        private readonly IAuthorisationService authorisationService;

        public AuthorisationModule(IAuthorisationService authorisationService)
        {
            this.authorisationService = authorisationService;

            Post["/{Key}/Authorisation"] = x =>
            {
                var command = new AuthorisationCredentialsCommand(new AccountContext(x.Key), IPAddress.Parse(Request.Form.IPAddress));
                var authToken = authorisationService.CreateAuthorisationToken(command);

                return Response.AsJson((string)authToken.TokenKey);
            };
        }
    }
}