using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace Caching
{
    //TODO: update memory cache provider if needed
    public class MemoryCacheProvider : ICacheProvider
    {
        private static readonly Lazy<MemoryCacheProvider> InstanceInit = new Lazy<MemoryCacheProvider>(() => new MemoryCacheProvider());
        public static MemoryCacheProvider Instance
        {
            get { return InstanceInit.Value; }
        }

        private MemoryCacheProvider()
        {
        }

        private MemoryCache _cache;
        internal MemoryCache Cache
        {
            get { return _cache ?? (_cache = new MemoryCache(Guid.NewGuid().ToString())); }
        }

        public object Get(string key)
        {
            return Cache.Get(key);
        }
        public void Add(string key, object data, DateTime absoluteTimeout, TimeSpan slidingTimeout, string category = null, System.Web.Caching.CacheItemPriority priority = System.Web.Caching.CacheItemPriority.Default)
        {
            var expiryTime = DateTime.UtcNow.AddMinutes(1);
            Cache.Add(key, data, expiryTime, category);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void ClearCategory(string category)
        {
            Cache.Remove(null, category);
        }





        public void FlushAll()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> CacheInfo
        {
            get { throw new NotImplementedException(); }
        }
    }
}
