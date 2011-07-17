using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetMeRate.Common
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object source)
        {
            if (source != null) return true;
            return false;
        }

        public static bool IsNull(this object source)
        {
            if (source == null) return true;
            return false;
        }
    }
}
