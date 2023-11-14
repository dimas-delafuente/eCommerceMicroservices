using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Common.Logging;

public static class ServiceCollectionExtensions
{
    public static IHostBuilder UseSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        hostBuilder
            .UseSerilog((context, config) =>
            {
                config
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", context.HostingEnvironment.ApplicationName)
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(GetElasticsearchSinkOptions(context, configuration))
                    .ReadFrom.Configuration(context.Configuration);
            });
        return hostBuilder;
    }

    private static ElasticsearchSinkOptions GetElasticsearchSinkOptions(HostBuilderContext context, IConfiguration configuration)
    {
        var appName = context.HostingEnvironment.ApplicationName.ToLower().Replace(".", "-");
        var environment = context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-");
        return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
        {
            IndexFormat = $"applogs-{appName}-{environment}-logs-{DateTime.UtcNow:yyyy-MM}",
            AutoRegisterTemplate = true,
            NumberOfShards = 2,
            NumberOfReplicas = 1
        };
    }
}
