using Order.DataAccess.Model;

namespace Order.DataAccess.Abstract
{
    public interface IOrderRepo
    {
        Task<string> CreateOrder(CreateOrderRequest order);
    }
}
