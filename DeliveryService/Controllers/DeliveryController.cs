using DeliveryService.Service;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers;

[ApiController]
[Route("api/delivery/")]
public class DeliveryController(ILogger<DeliveryController> logger, IDeliveryService deliveryService) : ControllerBase
{
    private readonly ILogger<DeliveryController> _logger = logger;
    private readonly IDeliveryService _deliveryService = deliveryService;

    [HttpGet("Health")]
    public IActionResult Health()
    {
        return Ok("Delivery Service is running!");
    }

    [HttpPost("assignDelivery")]
    public async Task<IActionResult> AssignDelivery()
    {
        //var serviceResponse = await _deliveryService.StartListening();
        return Ok();
    }

    [HttpGet("completeDelivery/")]

    public async Task<IActionResult> CompleteDeliveryByDeliveryId(int id)
    {
        //var serviceResponse = await _deliveryService.CompleteDeliveryAsync(id);
        return Ok();
    }
}