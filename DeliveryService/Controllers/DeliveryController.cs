using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers;

[ApiController]
[Route("api/delivery/")]
public class DeliveryController(ILogger<DeliveryController> logger) : ControllerBase
{
    private readonly ILogger<DeliveryController> _logger = logger;

    [HttpGet("Health")]
    public IActionResult Health()
    {
        return Ok("Delivery Service is running!");
    }
}