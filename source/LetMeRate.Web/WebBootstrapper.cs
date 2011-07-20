using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LetMeRate.Application;
using LetMeRate.Application.Security;
using LetMeRate.Application.Services;
using LetMeRate.Web.Helpers;
using Nancy;
using TinyIoC;

namespace LetMeRate.Web
{
    public class WebBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IAccountService, AccountService>().AsSingleton();
            container.Register<IRatingService, RatingService>().AsSingleton();

            container.Register<IAccountKeyGenerator, AccountKeyGenerator>().AsSingleton();
            container.Register<ISecurityDigest, SecurityDigest>().AsSingleton();

            container.Register<IHttpContextAccessor, HttpContextAccessor>().AsMultiInstance();
        }
    }
}