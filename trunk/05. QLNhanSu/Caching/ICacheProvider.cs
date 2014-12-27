using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Caching
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Add(string key, object data, DateTime absoluteTimeout, TimeSpan timeout, string category = null, CacheItemPriority priority = CacheItemPriority.Default);
        void Remove(string key);
        void ClearCategory(string category);
        void FlushAll();
        Dictionary<string, int> CacheInfo { get; }
    }
}
