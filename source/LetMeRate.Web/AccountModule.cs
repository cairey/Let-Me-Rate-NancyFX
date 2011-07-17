using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using LetMeRate.Application;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Services;
using Nancy;
using LetMeRate.Web.Helpers;

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
                                              var command = new AddUserAccountCommand(Request.Form.EmailAddress,
                                                                                  Request.Form.Password,
                                                                                  uint.Parse(Request.Form.RateOutOf));
                                              var account = _accountService.CreateAccount(command);

                                              //var accountValidationUrl = Request.BaseUrl() + "/Account/Validate";
                                              return Response.AsJson(new
                                                                         {
                                                                             AccountKey = account.Key, 
                                                                             AccountValidationUrl = ""
                                                                         });
            };
        }


        public static string GetBodyAsString(Request response)
        {
            using (var contentsStream = new MemoryStream())
            {
                response.Body.Position = 0;
                using (var streamReader = new StreamReader(response.Body))
                    return streamReader.ReadToEnd();
            }
        }
    }
}