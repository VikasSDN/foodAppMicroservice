using System.Text;
using DeliveryService.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DeliveryService.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public DeliveryService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void StartListening()
        {
            _channel.QueueDeclare(queue: "ordersQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var order = JsonConvert.DeserializeObject<Order>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                var partner = GetAvailablePartner();
                Console.WriteLine($"Order for {order.UserId} assigned to {partner.Name}");
            };
            _channel.BasicConsume(queue: "ordersQueue", autoAck: true, consumer: consumer);
        }

        public DeliveryPartner GetAvailablePartner()
        {
            // Simple logic for now to get an available delivery partner
            return new DeliveryPartner { Name = "John Doe", PhoneNumber = "123-456-7890", IsAvailable = true };
        }
    }
}
