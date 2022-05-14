using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Order.Business.Abstract;
using Order.Business.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;

namespace Order.Business.Concrete
{
    public class SendMailService : ISendMailService
    {
        private readonly ILogger<SendMailService> _logger;
        private readonly IRabitMQService _rabitMQService;
        private readonly IConnection _connection;
        private readonly IModel _model;

        public SendMailService(IRabitMQService rabitMQService,ILogger<SendMailService> logger)
        {
            _logger = logger;
            _rabitMQService = rabitMQService;
            _connection = _rabitMQService.RabitMQConnection();
            _model = _connection.CreateModel();
        }

        public void AddMailtoQueue(RabbitMailTemplate mailTemplate)
        {
            _model.QueueDeclare(mailTemplate.QueueName, false, false, false, null);
            _model.BasicPublish("", mailTemplate.QueueName, null, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mailTemplate)));
            _logger.LogInformation("Mail template added to RabbitMQ queue");
        }

        public async Task SendMailQueue(string queueName)
        {
            _model.QueueDeclare(queueName, false, false, false, null);
            var consumer = new EventingBasicConsumer(_model);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var mail = JsonConvert.DeserializeObject<RabbitMailTemplate> (Encoding.UTF8.GetString(body));
                var message = mail.MailAddress.ToString();
                _logger.LogInformation("An order e-mail has been sent to "+message);
            };
            _model.BasicConsume(queueName, true, consumer);
        }
    }
}
