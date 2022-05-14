using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Abstract;
using Order.DataAccess.Model;
using Order.Entity.Model;

namespace Order.DataAccess.Concrete
{
    public class OrderRepo : IOrderRepo
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderRepo(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<string> CreateOrder(CreateOrderRequest order)
        {
            var product = order.ProductDetails;
            foreach (var item in product)
            {
                var chechProduct =await CheckProduct(item.ProductId);
                if (chechProduct!=true)
                {
                    return null;
                }
            }
            var result =await CreateNewOrder(order);
            return result;
        }
        private async Task<bool> CheckProduct(Guid productId)
        {
            var product = await _orderDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id.Equals(productId));
            if (product == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private async Task<string> CreateNewOrder(CreateOrderRequest order)
        {
            var orderEntity = new OrderEntity();
            //var orderDetailEntity = new OrderDetailEntity();
            var orderId = Guid.NewGuid();
            orderEntity.Id = orderId;
            orderEntity.CustomerName = order.CustomerName;
            orderEntity.CustomerEmail = order.CustomerEmail;
            orderEntity.CustomerGSM = order.CustomerGSM;
            var totalAmount = 0;
            foreach (var item in order.ProductDetails)
            {
                _orderDbContext.OrderDetails.Add(new OrderDetailEntity
                {
                    Id= Guid.NewGuid(),
                    OrderId= orderId,
                    ProductId= item.ProductId,
                    UnitPrice= item.UnitPrice,
                });
                totalAmount += item.Amount;
            }
            orderEntity.TotalAmount = totalAmount;
            _orderDbContext.Orders.Add(orderEntity);
            await _orderDbContext.SaveChangesAsync();
            return orderEntity.Id.ToString();
        }
    }
}
