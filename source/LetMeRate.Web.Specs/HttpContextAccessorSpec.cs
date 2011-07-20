using System;
using System.Web;
using LetMeRate.Web.Helpers;
using Machine.Specifications;
using NSubstitute;

namespace LetMeRate.Web.Specs
{
    [Subject("when getting the base url")]
    public class HttpContextAccessorSpec
    {
        private Establish context = () =>
                                        {
                                            httpContextWrapper = Substitute.For<HttpContextBase>();
                                            httpRequestWrapper = Substitute.For<HttpRequestBase>();

                                            var baseUrl = new Uri("http://baseurl/fearfactory");
                                            httpRequestWrapper.Url.Returns(baseUrl);
                                            httpContextWrapper.Request.Returns(httpRequestWrapper);

                                            httpContextAccessor = new HttpContextAccessor(httpContextWrapper);
                                        };

        private Because of = () => result = httpContextAccessor.Current.Request.BaseUrl();

        private It should_return_a_valid_base_url = () => new Uri(result, UriKind.Absolute);


        private static HttpContextBase httpContextWrapper;
        private static HttpRequestBase httpRequestWrapper;
        private static HttpContextAccessor httpContextAccessor;
        private static string result;
    }
}
