using ErrorOr;
using MediatR;

namespace Common.Idempotency;

public sealed class IdempotentCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IdempotentCommand<TResponse>
    where TResponse : IErrorOr
{
    private readonly IIdempotencyService _idempotencyService;

    public IdempotentCommandBehavior(IIdempotencyService idempotencyService)
    {
        _idempotencyService = idempotencyService;
    }

    // TODO: it should be able to retrieve the idempotent response, so we can return the generated ID in 
    // any create operation.
    // Tried to serialize and deserialize the response storing it in DB, but it is not able to deserialize
    // a TResponse because is IErrorOr type and it is not generic...
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (await _idempotencyService.RequestExistsAsync(request.RequestId))
        {
            return default!;
        }

        await _idempotencyService.CreateRequestAsync(request.RequestId, typeof(TRequest).Name);

        var response = await next();

        return response;
    }
}
