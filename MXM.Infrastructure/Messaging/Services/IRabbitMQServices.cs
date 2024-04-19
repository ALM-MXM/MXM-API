using MXM.Infrastructure.Messaging.Contracts;


namespace MXM.Infrastructure.Messaging.Services
{
    internal class IRabbitMQServices : IRabbitMQRepository
    {
        public bool Publisher(object data, string routingKey)
        {
            throw new NotImplementedException();
        }
    }
}
