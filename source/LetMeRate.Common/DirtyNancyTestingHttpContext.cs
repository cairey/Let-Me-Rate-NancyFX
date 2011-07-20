using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LetMeRate.Common
{
    public static class DirtyNancyTestingHttpContext
    {
        public static HttpContextBase Current { get; set; }
    }
}
