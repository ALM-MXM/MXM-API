

namespace MXM.Infrastructure.Messaging.Contracts
{
    public interface IRabbitMQRepository
    {
        bool Publisher(object data, string routingKey);      
    }
}
