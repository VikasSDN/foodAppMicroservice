using DeliveryService.Context;
using DeliveryService.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddScoped<IDeliveryService, DeliveryService.Service.DeliveryService>();

builder.Services.AddDbContext<DeliveryDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DeliveryDbConnection"));
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Delivery Service API",
        Version = "v1",
        Description = "A simple example of a microserices Delivery Service API",
    });
});

var app = builder.Build();

app.UseSwagger(); // Serve Swagger documentation
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
