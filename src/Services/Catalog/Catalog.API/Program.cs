using Catalog.API.Errors;
using Catalog.Application;
using Catalog.Infrastructure;
using Common.Idempotency;
using Common.Logging;
using Common.Tracing;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Catalog.API", Version = "v1" });
});


builder.Services.AddInfrastructure(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddApplication();
builder.Services.AddSingleton<ProblemDetailsFactory, CatalogProblemDetailsFactory>();
builder.Services.AddIdempotency(builder.Configuration.GetSection("IdempotencyDbSettings"));

builder.Services.AddTracing(builder.Environment.ApplicationName);

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
