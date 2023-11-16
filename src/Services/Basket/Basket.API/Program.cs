using Basket.Application;
using Basket.Infrastructure;
using Common.Logging;
using Common.Tracing;
using EventBus.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration.GetSection("CacheSettings"),
        builder.Configuration.GetSection("DiscountGrpcSettings"));

builder.Services.AddTracing(builder.Environment.ApplicationName);

builder.Services.AddEventBus(opt =>
{
    opt.Host = builder.Configuration.GetSection("EventBusSettings")["HostAddress"];
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
