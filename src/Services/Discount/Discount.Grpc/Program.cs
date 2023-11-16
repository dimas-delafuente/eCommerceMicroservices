using Common.Logging;
using Common.Tracing;
using Discount.Application;
using Discount.Grpc.Services;
using Discount.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(builder.Configuration);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddInfrastructure(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddApplication();

builder.Services.AddTracing(builder.Environment.ApplicationName);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ProductDiscountService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
