using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LetMeRate.Application;
using LetMeRate.Application.Services;
using Nancy;

namespace LetMeRate.Web
{
    public class AccountModule : NancyModule
    {
        private readonly IAccountService _accountService;

        public AccountModule(IAccountService accountService)
        {
            _accountService = accountService;

            Get["/"] = x =>
            {
                return "Test Route";
            };

            Post["/Account/Create"] = x =>
                                          {
                                              string emailAddress = this.Request.Form.EmailAddress;
                                              string password = this.Request.Form.Password;
                                              _accountService.CreateAccount(emailAddress, password);

                return "Test";
            };
        }
    }
}