using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace LetMeRate.Web.Helpers
{
    public static class HttpRequestBaseExtensions
    {
        public static string BaseUrl(this HttpRequestBase source)
        {
            return source.Url.GetLeftPart(UriPartial.Authority);
        }
    }
}