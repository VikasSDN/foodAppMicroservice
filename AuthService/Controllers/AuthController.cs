
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/auth/")]
public class AuthController(ILogger<AuthController> logger) : ControllerBase
{
    private readonly ILogger<AuthController> _logger = logger;

    [HttpGet("Health")]
    public IActionResult Health()
    {
        return Ok("Auth Service is running!");
    }
}