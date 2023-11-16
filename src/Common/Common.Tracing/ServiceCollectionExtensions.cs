using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Common.Tracing;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTracing(this IServiceCollection services, string applicationName)
    {
        Activity.DefaultIdFormat = ActivityIdFormat.W3C;

        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource
                .AddService(serviceName: applicationName))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddGrpcClientInstrumentation()
                .AddOtlpExporter(opt =>
                {
                    opt.Endpoint = new Uri("http://jaeger:4317");
                })
                .AddConsoleExporter()
                .AddSource(GenericActivity.Name));

        return services;
    }
}