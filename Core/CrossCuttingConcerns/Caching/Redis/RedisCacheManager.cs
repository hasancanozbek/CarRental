
using System.Runtime.Serialization.Formatters.Binary;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheService
    {
        private readonly IDistributedCache distributedCache;

        public RedisCacheManager()
        {
            distributedCache = ServiceTool.ServiceProvider.GetService<IDistributedCache>();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            return distributedCache.Get(key);
        }

        public void Add(string key, object value, int duration)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.AbsoluteExpiration = DateTime.Now.AddMinutes(duration);
            BinaryFormatter bf = new BinaryFormatter();
            byte[] byteValue;
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, value);
                byteValue = ms.ToArray();
            }
            distributedCache.Set(key, byteValue, options);
        }

        public bool isAdded(string key)
        {
            var value = distributedCache.Get(key);
            if (value == null)
            {
                return false;
            }
            return true;
        }

        public void Remove(string key)
        {
            distributedCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
