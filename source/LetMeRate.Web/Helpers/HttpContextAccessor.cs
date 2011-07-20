using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LetMeRate.Common;

namespace LetMeRate.Web.Helpers
{
    public class HttpContextAccessor : IHttpContextAccessor
    {
        public HttpContextAccessor()
        {
            Current = HttpContext.Current == null ? DirtyNancyTestingHttpContext.Current : new HttpContextWrapper(HttpContext.Current);
        }

        public HttpContextAccessor(HttpContextBase httpContextBase)
        {
            Current = httpContextBase ?? new HttpContextWrapper(HttpContext.Current);
        }

        public HttpContextBase Current { get; private set; }
    }
}