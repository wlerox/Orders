using Microsoft.Extensions.Options;
using Order.Business.Abstract;
using Order.Business.Model;
using RabbitMQ.Client;
using System.Collections;
using System.Collections.Generic;

namespace Order.Business.Concrete
{
    public class RabitMQService : IRabitMQService
    {
        private readonly RabbitOptions _rabbitOptions;

        public RabitMQService(IOptions<RabbitOptions> rabbitOptions)
        {
            _rabbitOptions = rabbitOptions.Value;
        }

        public IConnection RabitMQConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _rabbitOptions.HostName,
                Port = _rabbitOptions.Port,
                UserName = _rabbitOptions.UserName,
                Password = _rabbitOptions.Password,
                VirtualHost = _rabbitOptions.VHost
            };
            var connection = factory.CreateConnection();
            return connection;
        }
    }
}
