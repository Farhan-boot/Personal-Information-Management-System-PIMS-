using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace PTSL.BdArmy.Web.Helper
{
    public class CachingHelper
    {
        private readonly MemoryCache _cache = MemoryCache.Default;
        public object Get<T>(string key)
        {
            return _cache.Get(key);
        }
        public void Put<T>(string key, T value)
        {
            _cache.Set(key, value, GetCacheItemPolicy(ObjectCache.InfiniteAbsoluteExpiration));
        }
        public void Put<T>(string key, T value, int validityInMin)
        {
            _cache.Set(key, value, GetCacheItemPolicy(DateTimeOffset.UtcNow.AddMinutes(validityInMin)));
        }
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
        private CacheItemPolicy GetCacheItemPolicy(DateTimeOffset absoluteExpiration)
        {
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = absoluteExpiration,
                SlidingExpiration = ObjectCache.NoSlidingExpiration
            };
            return cacheItemPolicy;
        }
    }
}
