using System;
using System.Web.Caching;

namespace Caching
{
    public class InvalidateKeyEventArgs : EventArgs
    {
        public string Key { get; private set; }
        public string CustomRemoteData { get; private set; }

        public InvalidateKeyEventArgs(string key, string customRemoteData)
        {
            Key = key;
            CustomRemoteData = customRemoteData;
        }
    }

    public class InvalidateCatagoryEventArgs : EventArgs
    {
        public string Catagory { get; private set; }


        public InvalidateCatagoryEventArgs(string catagory)
        {
            Catagory = catagory;
        }
    }

    public class AddKeyEventArgs : EventArgs
    {
        public AddKeyEventArgs(string key, object data, DateTime absoluteTimeout, TimeSpan slidingTimeout, string category, CacheItemPriority priority, string customRemoteData)
        {
            Key = key;
            Data = data;
            AbsoluteTimeout = absoluteTimeout;
            SlidingTimeout = slidingTimeout;
            Category = category;
            Priority = priority;
            CustomRemoteData = customRemoteData;
        }

        public string Key { get; private set; }
        public object Data { get; private set; }
        public DateTime AbsoluteTimeout { get; private set; }
        public TimeSpan SlidingTimeout { get; private set; }
        public string Category { get; private set; }
        public CacheItemPriority Priority { get; private set; }
        public string CustomRemoteData { get; private set; }
    }

    public interface ISupportDistributedCacheInvalidation
    {
        event EventHandler<InvalidateKeyEventArgs> InvalidateKeyEvent;
        event EventHandler<AddKeyEventArgs> AddNewKeyEvent;
        event EventHandler<InvalidateCatagoryEventArgs> InvalidateCatagoryEvent;

        void InvalidateKey(string key, string customRemoteData = null);
        void InvalidateCategory(string key);
        void AddKeyToOtherInstances(string key, object data, DateTime absoluteTime, TimeSpan slidingTimeout, string category = null, CacheItemPriority priority = CacheItemPriority.Default, string customRemoteData = null);
    }
}
