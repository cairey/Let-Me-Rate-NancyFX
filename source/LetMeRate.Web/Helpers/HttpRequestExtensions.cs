using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace LetMeRate.Web.Helpers
{
    public static class HttpRequestExtensions
    {
        public static HttpRequest HttpRequest(this Request source)
        {
            return HttpContext.Current.Request;
        }


        public static string BaseUrl(this Request source)
        {
            return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        }
    }
}