using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("searchRestaurant")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Restaurant>>> SearchRestaurants([FromBody] string RestaurantName)
    {
        return await _context.Restaurants.Where(r => r.Name.Contains(RestaurantName)).ToListAsync();
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
    {
        return await _context.Restaurants.Include(r => r.MenuItem).ToListAsync();
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
    {
        var restaurant = await _context.Restaurants.Include(r => r.MenuItem)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (restaurant == null)
            return NotFound();

        return restaurant;
    }

    [HttpGet("menu/{id}")]
    [Authorize]
    public async Task<ActionResult<MenuItem>> GetRestaurantMenu(int id)
    {
        var MenuItems = await _context.MenuItems.FirstOrDefaultAsync(r => r.Id == id);

        if (MenuItems == null)
            return NotFound();

        return MenuItems;
    }
}