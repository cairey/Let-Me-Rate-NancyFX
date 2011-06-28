using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace LetMeRate.Web
{
    public class MainModule : NancyModule
    {
        public MainModule()
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