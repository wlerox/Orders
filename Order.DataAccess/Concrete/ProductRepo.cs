using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Abstract;
using Order.Entity.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DataAccess.Concrete
{
    public class ProductRepo : IProductRepo
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly IMapper _mapper;

        public ProductRepo(OrderDbContext orderDbContext, IMapper mapper)
        {
            _orderDbContext = orderDbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var allProduct = await _orderDbContext.Products.ToListAsync();
            if(allProduct != null)
            {
                var productList = _mapper.Map<List<ProductDto>>(allProduct);
                return productList;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProductDto>> GetProductsByCategory(string category)
        {
            var produsts = await _orderDbContext.Products.Where(x => x.Category==category).ToListAsync();
            if (produsts != null)
            {
                var productList = _mapper.Map<List<ProductDto>>(produsts);
                return productList;
            }
            else
            {
                return null;
            }
        }
    }
}
