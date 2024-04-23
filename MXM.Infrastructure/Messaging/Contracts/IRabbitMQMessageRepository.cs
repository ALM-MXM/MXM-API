

namespace MXM.Infrastructure.Messaging.Contracts
{
    public interface IRabbitMQMessageRepository
    {
        Task<bool> Publisher(object data, string routingKey);        
    }
}
