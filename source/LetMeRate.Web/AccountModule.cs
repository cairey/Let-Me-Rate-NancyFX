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
        private readonly HttpContextBase context;

        public AccountModule(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            this.context = httpContextAccessor.Current;

            Get["/"] = x =>
                           {

                return "Test Route";
            };


            Post["/Account/Create"] = x =>
                                          {
                                              var command = new AddUserAccountCommand(Request.Form.EmailAddress,
                                                                                  Request.Form.Password,
                                                                                  uint.Parse(Request.Form.RateOutOf));
                                              var account = accountService.CreateAccount(command);

                                              var accountValidationUrl = context.Request.BaseUrl() + "/Account/Validate/" + account.Key;
                                              
                                              return Response.AsJson(new
                                                                         {
                                                                             AccountKey = account.Key,
                                                                             AccountValidationUrl = accountValidationUrl
                                                                         });
            };

            Get["/Account/Validate/{ValidationKey}"] = x =>
                                                           {
                                                               var command = new ValidateAccountCommand(x.ValidationKey);
                                                               accountService.ValidateAccount(command);
                return "Test Route";
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