using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace Mento.Utility
{
    public static class CacheHelper
    {
        private static MemoryCache DefaultCache = MemoryCache.Default;

        public static bool Add(string key, object value)
        {
            return Add(key, value, TimeSpan.FromDays(1));
        }

        public static bool Add(string key, object value, TimeSpan expiration)
        {
            return DefaultCache.Add(key, value, new CacheItemPolicy() { SlidingExpiration = expiration });
        }

        public static object Get(string key)
        {
            return DefaultCache.Get(key);
        }


    }
}
