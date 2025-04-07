using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderService.Model;
using OrderService.Service;
using RabbitMQ.Client;

namespace OrderService.Controllers;

[ApiController]
[Route("api/order/")]
public class OrderController(ILogger<OrderController> logger, RabbitMqService rabbitMqService) : ControllerBase
{
    private readonly ILogger<OrderController> _logger = logger;
    private readonly IModel _channel = rabbitMqService.Channel;

    [HttpGet("Health")]
    public IActionResult Health()
    {
        return Ok("Order Service is running!");
    }

    [HttpPost]
    public IActionResult PlaceOrder([FromBody] Order order)
    {
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(order));
        _channel.BasicPublish(exchange: "",
                              routingKey: "ordersQueue",
                              basicProperties: null,
                              body: body);

        return Ok(new { message = "Order placed successfully" });
    }
}