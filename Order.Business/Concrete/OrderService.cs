using Microsoft.Extensions.Logging;
using Order.Business.Abstract;
using Order.Business.Model;
using Order.DataAccess.Abstract;
using Order.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepo _orderRepo;
        private readonly ISendMailService _sendMailService;

        public OrderService(ILogger<OrderService> logger, IOrderRepo orderRepo, ISendMailService sendMailService)
        {
            _logger = logger;
            _orderRepo = orderRepo;
            _sendMailService = sendMailService;
        }

        public async Task<string> CreateOrder(CreateOrderRequest createOrder)
        {
            var order = await _orderRepo.CreateOrder(createOrder);
            if (order != null)
            {
                _logger.LogInformation("The order has been created");
                var mailTemp = new RabbitMailTemplate();
                mailTemp.QueueName = "sendMail";
                mailTemp.MailAddress = createOrder.CustomerEmail;
                mailTemp.Message = order;
                _logger.LogInformation("Email address added to mail queue");
                _sendMailService.AddMailtoQueue(mailTemp);
            }
            return order;
        }
    }
}
