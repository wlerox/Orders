using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Order.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Business.Concrete
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<CacheService> _logger; 
        public CacheService(IDistributedCache distributedCache, ILogger<CacheService> logger)
        {
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public async Task<string> GetProductFromCache(string key)
        {
            var personsFromCache = await _distributedCache.GetStringAsync(key);
            return personsFromCache;
        }

        public async Task SetProductsToCache(string products, string key)
        {
            await _distributedCache.SetStringAsync(key, products);
        }
    }
}
