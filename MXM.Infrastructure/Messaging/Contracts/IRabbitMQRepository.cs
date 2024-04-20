

namespace MXM.Infrastructure.Messaging.Contracts
{
    public interface IRabbitMQRepository
    {
        Task<bool> Publisher(object data, string routingKey);      
    }
}
