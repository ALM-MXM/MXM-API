using RabbitMQ.Client;


namespace MXM.Infrastructure.Messaging.Contracts
{
    public interface IRabbitMQConnectionRepository
    {
        IModel GetConnection();
    }
}
