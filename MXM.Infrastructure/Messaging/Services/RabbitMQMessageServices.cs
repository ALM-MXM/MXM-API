using Microsoft.Extensions.Configuration;
using MXM.Infrastructure.Messaging.Contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;


namespace MXM.Infrastructure.Messaging.Services
{
    internal class RabbitMQMessageServices : IRabbitMQMessageRepository
    {
        private IModel _channel;
        private readonly IRabbitMQConnectionRepository _connectionRepository;

        public RabbitMQMessageServices(IRabbitMQConnectionRepository rabbitMQConnectionRepository)
        {
            try
            {
                _connectionRepository = rabbitMQConnectionRepository;
                _channel = _connectionRepository.GetConnection();
            }catch (Exception ex)
            {
              throw new Exception(ex.Message);
            }            
        }

        public async Task<bool> Publisher(object data, string routingKey)
        {
            try
            {
                var body =  JsonConvert.SerializeObject(data);
                var bodyByteArray = Encoding.UTF8.GetBytes(body);
                _channel.QueueDeclare(
                    queue: $"{routingKey}",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );
                _channel.ConfirmSelect();
                _channel.BasicPublish(
                    string.Empty,
                    routingKey,
                    null,
                    bodyByteArray
                    );
                if ( _channel.WaitForConfirms(TimeSpan.FromSeconds(10)))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
       
    }
}
