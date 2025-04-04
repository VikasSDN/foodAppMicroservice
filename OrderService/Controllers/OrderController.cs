using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

[ApiController]
[Route("api/order/")]
public class OrderController(ILogger<OrderController> logger) : ControllerBase
{
    private readonly ILogger<OrderController> _logger = logger;

    [HttpGet("Health")]
    public IActionResult Health()
    {
        return Ok("Order Service is running!");
    }
}