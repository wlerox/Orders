using RabbitMQ.Client;
namespace Order.Business.Abstract
{
    public interface IRabitMQService
    {
        IConnection RabitMQConnection();
    }
}
