using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Business.Abstract
{
    public interface ICacheService
    {
        Task<string> GetProductFromCache(string key);
        Task SetProductsToCache(string products, string key);
    }
}
