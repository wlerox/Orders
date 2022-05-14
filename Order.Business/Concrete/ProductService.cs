using Order.Business.Abstract;
using Order.DataAccess.Abstract;
using Order.Entity.DtoModel;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Order.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepo _productRepo;
        private readonly ICacheService _cacheService;

        public ProductService(ILogger<ProductService> logger, IProductRepo productRepo, ICacheService cacheService)
        {
            _logger = logger;
            _productRepo = productRepo;
            _cacheService = cacheService;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = new List<ProductDto>();
            if (String.IsNullOrEmpty(await _cacheService.GetProductFromCache("AllProducts")))
            {
                var allProducts = await _productRepo.GetAllProducts();
                if (allProducts != null)
                {
                    _logger.LogInformation("Data is being cached from database");
                    SetAllProductInCacheAsync(allProducts, "AllProducts");
                    products = allProducts;
                }
                else
                {
                    products = null;
                }

            }
            else
            {
                _logger.LogInformation("Data is being retrieved from the cache");
                products = await GetAllProductsInCache("AllProducts");
            }
            
            return products;
        }

       

        public async Task<List<ProductDto>> GetProductsByCategory(string category)
        {
            var products = new List<ProductDto>();
            if (String.IsNullOrEmpty(await _cacheService.GetProductFromCache(category)))
            {
                var allProducts = await _productRepo.GetProductsByCategory(category);
                if (allProducts != null)
                {
                    _logger.LogInformation("Data is being cached from database");
                    SetAllProductInCacheAsync(allProducts,category);
                    products = allProducts;
                }
                else
                {
                    products = null;
                }

            }
            else
            {
                _logger.LogInformation("Data is being retrieved from the cache");
                products = await GetAllProductsInCache(category);
            }
            //products = await _productRepo.GetProductsByCategory(category);
            return products;
        }

        private async Task<List<ProductDto>> GetAllProductsInCache(string key)
        {
            var products = await _cacheService.GetProductFromCache(key);
            var allProducts = JsonConvert.DeserializeObject<List<ProductDto>>(products);
            return allProducts;
        }

        private async Task SetAllProductInCacheAsync(List<ProductDto> allProducts, string key)
        {
            var productsConvertToString = JsonConvert.SerializeObject(allProducts);
            await _cacheService.SetProductsToCache(productsConvertToString, key);
        }
    }
}
