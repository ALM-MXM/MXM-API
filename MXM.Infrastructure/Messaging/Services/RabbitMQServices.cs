using Microsoft.Extensions.Configuration;
using MXM.Infrastructure.Messaging.Contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MXM.Infrastructure.Messaging.Services
{
    internal class RabbitMQServices : IRabbitMQRepository
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IConfiguration _configuration;
        public RabbitMQServices(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                UserName = _configuration["ConnectRabbitMQServices:UserName"],
                Password = _configuration["ConnectRabbitMQServices:Password"],
                HostName = _configuration["ConnectRabbitMQServices:HostName"],
                VirtualHost = _configuration["ConnectRabbitMQServices:VirtualHost"],
                Port = int.Parse(_configuration["ConnectRabbitMQServices:Port"])
            };

            //Caso o servidor Online não funcionar 
            //var factory = new ConnectionFactory()
            //{              
            //    HostName = "localhost",               
            //};
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public bool Publisher(object data, string routingKey)
        {
            try
            {
                var body = JsonConvert.SerializeObject(data);
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
                if (_channel.WaitForConfirms(TimeSpan.FromSeconds(10)))
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
