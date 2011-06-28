using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LetMeRate.Application;
using Nancy;
using TinyIoC;

namespace LetMeRate.Web
{
    public class WebBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IAccountService, AccountService>().AsSingleton();
        }
    }
}