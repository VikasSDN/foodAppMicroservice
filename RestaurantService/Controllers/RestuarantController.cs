using Microsoft.AspNetCore.Mvc;

namespace ReastaurantService.Controllers;

[ApiController]
[Route("api/restaurant/")]
public class RestaurantController(ILogger<RestaurantController> logger) : ControllerBase
{
    private readonly ILogger<RestaurantController> _logger = logger;

    [HttpGet("Health")]
    public IActionResult Health()
    {
        return Ok("Restaurant Service is running!");
    }
}