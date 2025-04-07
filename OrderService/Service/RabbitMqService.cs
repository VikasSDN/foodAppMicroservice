using RabbitMQ.Client;

namespace OrderService.Service
{
    public class RabbitMqService
    {
        public IConnection Connection { get; }
        public IModel Channel { get; }

        public RabbitMqService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
        }
    }
}
