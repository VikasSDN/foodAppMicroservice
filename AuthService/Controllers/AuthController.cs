
using AuthService.Model;
using AuthService.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/auth/")]
public class AuthController(ILogger<AuthController> logger, IAuthService authService) : ControllerBase
{
    private readonly ILogger<AuthController> _logger = logger;
    private readonly IAuthService _authService = authService;

    [HttpGet("Health")]
    public IActionResult Health()
    {
        return Ok("Auth Service is running!");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User loginUser)
    {
        var user = AuthenticateUser(loginUser);
        if (user == null)
            return Unauthorized();

        var token = _authService.GenerateJwtToken(user);
        return Ok(new { token });
    }

    private User AuthenticateUser(User loginUser)
    {
        return new User { Username = loginUser.Username, Role = "User" };
    }
}