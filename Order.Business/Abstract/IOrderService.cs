using Order.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Business.Abstract
{
    public interface IOrderService
    {
        Task<string> CreateOrder(CreateOrderRequest createOrder);
    }
}
