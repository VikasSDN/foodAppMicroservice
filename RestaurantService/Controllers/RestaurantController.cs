using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantService.Context;
using RestaurantService.Model;

namespace ReastaurantService.Controllers;

[ApiController]
[Route("api/restaurant/")]
public class RestaurantController(ILogger<RestaurantController> logger, RestaurantDbContext context) : ControllerBase
{
    private readonly ILogger<RestaurantController> _logger = logger;
    private readonly RestaurantDbContext _context = context;


    [HttpGet("Health")]
    public IActionResult Health()
    {
        return Ok("Restaurant Service is running!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
    {
        return await _context.Restaurants.Include(r => r.MenuItem).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
    {
        var restaurant = await _context.Restaurants.Include(r => r.MenuItem)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (restaurant == null)
        {
            return NotFound();
        }

        return restaurant;
    }
}