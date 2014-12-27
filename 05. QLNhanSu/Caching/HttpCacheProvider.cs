using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Caching
{
    public class HttpCacheProvider : ICacheProvider
    {
        private static readonly Lazy<HttpCacheProvider> InstanceInit = new Lazy<HttpCacheProvider>(() => new HttpCacheProvider());

        public static HttpCacheProvider Instance
        {
            get { return InstanceInit.Value; }
        }

        //private Cache _cache;
        internal Cache Cache
        {
            get
            {
                return HttpContext.Current != null && HttpContext.Current.Cache != null
                                            ? HttpContext.Current.Cache
                                            : HttpRuntime.Cache;
            }
        }

        public HttpCacheProvider()
        {
        }

        public object Get(string key)
        {
            return Cache.Get(key);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public void Add(string key, object data, DateTime absoluteTimeout, TimeSpan slidingTimeout, string category = null, CacheItemPriority priority = CacheItemPriority.Default)
        {
            if (!string.IsNullOrEmpty(category))
            {
                var rootkey = Cache.Get(category);
                if (rootkey == null)
                {
                    Cache.Insert(category, new object());
                }
                Cache.Insert(key, data, new CacheDependency(null, new[] { category }), absoluteTimeout, slidingTimeout, priority, null);
            }
            else
            {
                Cache.Insert(key, data, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero, priority, null);
            }
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void ClearCategory(string category)
        {
            Cache.Remove(category);
        }


        public void FlushAll()
        {
            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Cache.Remove(enumerator.Key.ToString());
            }
        }

        public Dictionary<string, int> CacheInfo
        {
            get
            {
                Dictionary<string, int> _info = new Dictionary<string, int>();
                IDictionaryEnumerator _items = Cache.GetEnumerator();
                while (_items.MoveNext())
                {
                    _info.Add(_items.Key.ToString(), GetObjectSize(_items.Value));
                }
                return _info;
            }
        }

        private int GetObjectSize(object TestObject)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                byte[] Array;
                bf.Serialize(ms, TestObject);
                Array = ms.ToArray();
                return Array.Length;
            }
            catch (Exception)
            {
                //unsafe
                //{
                //    try
                //    {

                //        object obj = new List<int>(); // whatever you want to get the size of
                //        RuntimeTypeHandle th = obj.GetType().TypeHandle;
                //        int _size = *(*(int**)th.Value + 1);
                //        return _size;

                //    }
                //    catch (Exception)
                //    {
                return -1;
                //    }
                //}
            }
        }
    }
}
