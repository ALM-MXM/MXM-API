using Microsoft.Extensions.Configuration;
using MXM.Infrastructure.Messaging.Contracts;
using RabbitMQ.Client;

namespace MXM.Infrastructure.Messaging.Services
{
    internal class RabbitMQConnectionServices : IRabbitMQConnectionRepository, IDisposable
    {
        private IConnection _connection;
        private readonly ConnectionFactory _connectionFactory;
        private IModel _channel;
        private readonly IConfiguration _configuration;

        public RabbitMQConnectionServices(IConfiguration configuration)
        {

            _configuration = configuration;
            _connectionFactory = new ConnectionFactory()
            {
                UserName = _configuration["ConnectRabbitMQServices:UserName"],
                Password = _configuration["ConnectRabbitMQServices:Password"],
                HostName = _configuration["ConnectRabbitMQServices:HostName"],
                VirtualHost = _configuration["ConnectRabbitMQServices:VirtualHost"],
                Port = int.Parse(_configuration["ConnectRabbitMQServices:Port"])
            };
        }

        public IModel GetConnection()
        {
            try
            {
                if (_connection == null || !_connection.IsOpen)
                {
                    _connection = _connectionFactory.CreateConnection();
                    _channel = _connection.CreateModel();
                }
                return _channel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
