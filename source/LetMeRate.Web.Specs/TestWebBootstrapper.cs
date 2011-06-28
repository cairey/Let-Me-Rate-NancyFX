using System;
using System.IO;
using Nancy;
using Nancy.Testing;
using Nancy.Testing.Fakes;

namespace LetMeRate.Web.Specs
{
    public class TestWebBootstrapper : WebBootstrapper
    {
        protected override Type RootPathProvider
        {
            get
            {
                // TODO - figure out a nicer way to do this
                var assemblyPath = Path.GetDirectoryName(typeof(WebBootstrapper).Assembly.CodeBase).Replace(@"file:\", string.Empty);
                var rootPath = PathHelper.GetParent(assemblyPath, 3);
                rootPath = Path.Combine(rootPath, @"LetMeRate.Web");

                FakeRootPathProvider.RootPath = rootPath;

                return typeof(FakeRootPathProvider);
            }
        }


    }
}