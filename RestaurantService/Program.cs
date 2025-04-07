using Microsoft.EntityFrameworkCore;
using RestaurantService.Context;
using RestaurantService.Services.IServices;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddScoped<IRestaurantservice, RestaurantService.Services.RestaurantService>();

builder.Services.AddDbContext<RestaurantDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbConnection"));
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
