using System.Text;
using Newtonsoft.Json;
using OrderService.Model;
using RabbitMQ.Client;

namespace OrderService.Service
{
    public class OrderService : IOrderService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public OrderService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void PlaceOrder(Order order)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(order));
            _channel.BasicPublish(exchange: "",
                                 routingKey: "ordersQueue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
