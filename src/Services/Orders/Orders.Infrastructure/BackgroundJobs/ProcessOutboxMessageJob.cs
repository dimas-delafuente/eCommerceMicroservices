using Common.Primitives.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Orders.Infrastructure.Contexts;
using Orders.Infrastructure.Outbox;
using Polly;
using Polly.Retry;
using Quartz;

namespace Orders.Infrastructure.BackgroundJobs;

[DisallowConcurrentExecution]
public sealed class ProcessOutboxMessageJob : IJob
{
    private readonly OrdersContext _dbContext;
    private readonly IPublisher _publisher;
    private readonly ILogger<ProcessOutboxMessageJob> _logger;

    public ProcessOutboxMessageJob(OrdersContext dbContext, IPublisher publisher, ILogger<ProcessOutboxMessageJob> logger)
    {
        _dbContext = dbContext;
        _publisher = publisher;
        _logger = logger;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        List<OutboxMessage> unprocessedOutboxMessages = await _dbContext
            .Set<OutboxMessage>()
            .Where(m => m.ProcessedOnUtc == null)
            .Take(20)
            .ToListAsync(context.CancellationToken);

        if (unprocessedOutboxMessages.Count > 0)
        {
            foreach (var outboxMessage in unprocessedOutboxMessages)
            {
                IDomainEvent? domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
                    outboxMessage.Content,
                    new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                if (domainEvent is not null)
                {
                    AsyncRetryPolicy policy = Policy
                        .Handle<Exception>()
                        .WaitAndRetryAsync(3, attempt => TimeSpan.FromMilliseconds(50 * attempt));

                    var result = await policy.ExecuteAndCaptureAsync(()
                        =>
                    {
                        _logger.LogInformation($"Publishing event: {domainEvent.GetType()}.");
                        return _publisher.Publish(domainEvent, context.CancellationToken);
                    });

                    outboxMessage.Error = result.FinalException?.ToString();
                    outboxMessage.ProcessedOnUtc = DateTime.UtcNow;
                }
            }

            _ = await _dbContext.SaveChangesAsync();
        }
    }
}
