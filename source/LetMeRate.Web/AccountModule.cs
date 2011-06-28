using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace LetMeRate.Web
{
    public class AccountModule : NancyModule
    {
        public AccountModule()
        {
          
            Get["/"] = x =>
            {
                return "Test Route";
            };

            Get["/test"] = x =>
            {
                return "Test";
            };
        }
    }
}