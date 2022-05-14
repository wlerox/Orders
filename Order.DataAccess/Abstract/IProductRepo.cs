using Order.Entity.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DataAccess.Abstract
{
    public  interface IProductRepo
    {
        Task<List<ProductDto>> GetAllProducts();
        Task<List<ProductDto>> GetProductsByCategory(string category);
    }
}
