using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Utils
{
    public class CacheKeys
    {
        public static string BuildBenhNhanCacheKey(string msbn)
        {
            return string.Format("User_{0}", msbn);
        }
    }
}
