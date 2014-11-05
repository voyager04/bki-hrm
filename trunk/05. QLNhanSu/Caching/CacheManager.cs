using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Caching;
using log4net;
using Framework.Extensions;

namespace Caching
{
    public class CacheManager
    {
        #region Fields
        private static ICacheProvider _provider = new HttpCacheProvider();
        private static ISupportDistributedCacheInvalidation _invalidator;
        private static CacheManager _instance;
        private bool _enabled = true;
        private bool _enableRemoveRemoteCache = true;
        private bool _enableAddRemoteCache = false;
        private static ILog _logger;

        private static TimeSpan _slidingTimeoutUserData;
        private static TimeSpan _slidingTimeoutCommonData;
        private static TimeSpan _slidingTimeoutImportantCommonData;
        #endregion

        #region Constructors
        static CacheManager()
        {
            _instance = CacheManager.Instance;
            _slidingTimeoutUserData = TimeSpan.FromMinutes(double.Parse(ConfigurationUtility.GetConfigurationSettingValue("SlidingTimeoutUserData")));
            _slidingTimeoutCommonData = TimeSpan.FromMinutes(double.Parse(ConfigurationUtility.GetConfigurationSettingValue("SlidingTimeoutCommonData")));
            _slidingTimeoutImportantCommonData = TimeSpan.FromMinutes(double.Parse(ConfigurationUtility.GetConfigurationSettingValue("SlidingTimeoutImportantCommonData")));
            SlidingTimeoutQuickCachingData = TimeSpan.FromSeconds(double.Parse(ConfigurationUtility.GetConfigurationSettingValue("SlidingTimeoutQuickCachingData")));
            SlidingTimeoutReportCachingData = TimeSpan.FromSeconds(double.Parse(ConfigurationUtility.GetConfigurationSettingValue("SlidingTimeoutReportCachingData")));
            _logger = LogManager.GetLogger(typeof(CacheManager));
        }

        public CacheManager(ICacheProvider provider)
            : this(provider, null)
        {
        }


        public CacheManager(ICacheProvider provider, ISupportDistributedCacheInvalidation invalidator)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            _provider = provider;

            if (invalidator != null)
            {
                _invalidator = invalidator;
                _invalidator.AddNewKeyEvent += _invalidator_AddNewKeyEvent;
                _invalidator.InvalidateKeyEvent += _invalidator_InvalidateKeyEvent;
                _invalidator.InvalidateCatagoryEvent += new EventHandler<InvalidateCatagoryEventArgs>(_invalidator_InvalidateCatagoryEvent);
            }
        }

        #endregion

        #region Events
        public event EventHandler<AddKeyEventArgs> RemoteCacheItemAdded;
        public event EventHandler<InvalidateKeyEventArgs> RemoteCacheItemRemoved;
        #endregion

        #region Properties
        public static ILog Logger
        {
            get
            {
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        public bool EnableRemoveRemoteCache
        {
            get
            {
                return _enableRemoveRemoteCache;
            }
            set
            {
                _enableRemoveRemoteCache = value;
            }
        }

        public bool EnableAddRemoteCache
        {
            get
            {
                return _enableAddRemoteCache;
            }
            set
            {
                _enableAddRemoteCache = value;
            }
        }

        public static CacheManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CacheManager(_provider);
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        public static TimeSpan SlidingTimeoutQuickCachingData { get; private set; }

        public static TimeSpan SlidingTimeoutReportCachingData { get; private set; }

        public static TimeSpan SlidingTimeoutUserData
        {
            get
            {
                return _slidingTimeoutUserData;
            }
        }

        public static TimeSpan SlidingTimeoutCommonData
        {
            get
            {
                return _slidingTimeoutCommonData;
            }
        }

        public static TimeSpan SlidingTimeoutImportantCommonData
        {
            get
            {
                return _slidingTimeoutImportantCommonData;
            }
        }

        #endregion

        #region Private methods
        void _invalidator_InvalidateKeyEvent(object sender, InvalidateKeyEventArgs e)
        {
            _logger.DebugFormat("Received remote cache remove key {0} with custom data {1}", new object[] { e.Key, e.CustomRemoteData });
            //if no custom data, clear data here!!
            if (e.CustomRemoteData.IsNullOrEmpty())
            {
                _logger.DebugFormat("Removed data from remote cache key {0} with custom data {1}", new object[] { e.Key, e.CustomRemoteData });
                _provider.Remove(e.Key);
            }
            //if have custom data, do no clear data, raise event for managers to process data
            else if (RemoteCacheItemRemoved != null)
                RemoteCacheItemRemoved(this, e);
        }

        void _invalidator_InvalidateCatagoryEvent(object sender, InvalidateCatagoryEventArgs e)
        {
            _logger.DebugFormat("Received remote cache remove catagory {0}", new object[] { e.Catagory });
            _provider.ClearCategory(e.Catagory);
        }

        void _invalidator_AddNewKeyEvent(object sender, AddKeyEventArgs e)
        {
            _logger.DebugFormat("Received add cache key {0} custom data {1}", new object[] { e.Key, e.CustomRemoteData });
            //add directly to cache if no custom data and has some data
            if (e.CustomRemoteData.IsNullOrEmpty() && e.Data != null)
            {
                _logger.DebugFormat("Added data from remote cache key {0} custom data {1}", new object[] { e.Key, e.CustomRemoteData });
                _provider.Add(e.Key, e.Data, e.AbsoluteTimeout, e.SlidingTimeout, e.Category, e.Priority);
            }
            //if have custom data or dont have data, raise event for managers to process data
            else if (RemoteCacheItemAdded != null)
                RemoteCacheItemAdded.Invoke(this, e);
        }
        #endregion

        #region Public methods
        public object Get(string key)
        {
            if (!_enabled)
                return null;
            var o = _provider.Get(key);
            if (o == null)
            {
                _logger.DebugFormat("Miss cache key {0}", new object[] { key });
            }
            return o;
        }

        public void Add(string key, object data)
        {
            Add(key, data, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public void Add(string key, object data, TimeSpan slidingTimeout)
        {
            Add(key, data, Cache.NoAbsoluteExpiration, slidingTimeout);
        }

        public void Add(string key, object data, DateTime absoluteTime)
        {
            Add(key, data, absoluteTime, Cache.NoSlidingExpiration);
        }

        public void Add(string key, object data, string customRemoteData)
        {
            Add(key, data, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, null, CacheItemPriority.Normal, customRemoteData);
        }

        public void Add(string key, object data, DateTime absoluteTimeout, TimeSpan timeout, string category = null, CacheItemPriority priority = CacheItemPriority.Normal, string customRemoteData = null)
        {
            if (!_enabled)
                return;
            _logger.DebugFormat("add cache key {0}", new object[] { key });
            timeout = TimeSpan.FromMinutes(10);
            _provider.Add(key, data, absoluteTimeout, timeout, category, priority);
            //if (_enableAddRemoteCache && _invalidator != null)
            //{
            //    Dictionary<string, object> Values = new Dictionary<string, object>();
            //    Values.Add("0", key);
            //    Values.Add("1", data);
            //    Values.Add("2", absoluteTimeout);
            //    Values.Add("3", timeout);
            //    Values.Add("4", category);
            //    Values.Add("5", priority);
            //    Values.Add("6", customRemoteData);
            //    ThreadPool.QueueUserWorkItem(dic =>
            //    {
            //        try
            //        {
            //            Dictionary<string, object> values = dic as Dictionary<string, object>;
            //            _invalidator.AddKeyToOtherInstances(values["0"] as string, values["1"], (DateTime)values["2"], (TimeSpan)values["3"], (string)values["4"], (CacheItemPriority)values["5"], (string)values["6"]);
            //        }
            //        catch (Exception ex)
            //        {
            //            ex.Log();
            //        }
            //    }, Values);
            //}
        }

        public void Remove(string key, string customRemoteData = null)
        {
            _logger.DebugFormat("remove cache key {0}", new object[] { key });
            _provider.Remove(key);
            if (_enableRemoveRemoteCache && _invalidator != null)
            {
                var Values = new Dictionary<string, object>();
                Values["0"] = key;
                Values["1"] = customRemoteData;
                ThreadPool.QueueUserWorkItem(dic =>
                {
                    try
                    {
                        Dictionary<string, object> values = dic as Dictionary<string, object>;
                        _invalidator.InvalidateKey(values["0"] as string, values["1"] as string);
                    }
                    catch (Exception ex)
                    {
                        ex.Log();
                    }
                }, Values);
            }
        }

        public void ClearCategory(string category)
        {
            _logger.DebugFormat("clear catagory {0}", new object[] { category });
            _provider.ClearCategory(category);
            if (_enableRemoveRemoteCache && _invalidator != null)
            {
                ThreadPool.QueueUserWorkItem(dic =>
                {
                    try
                    {
                        _invalidator.InvalidateCategory(dic.ToString());
                    }
                    catch (Exception ex)
                    {
                        ex.Log();
                    }
                }, category);
            }
        }

        public void FlushAll()
        {
            _logger.DebugFormat("START FLUSHING ALL CACHES at {0}", DateTime.Now);
            _provider.FlushAll();
            _logger.DebugFormat("FLUSHED :{0}", DateTime.Now);
        }

        public Dictionary<string, int> CacheInfo
        {
            get
            {
                return _provider.CacheInfo;
            }
        }
        #endregion
    }
}
