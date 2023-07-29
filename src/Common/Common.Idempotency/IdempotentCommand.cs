using Common.Primitives.Commands;
using ErrorOr;

namespace Common.Idempotency;

public abstract record IdempotentCommand<TCommandResult>(Guid RequestId) : ICommand<TCommandResult>
    where TCommandResult : IErrorOr;
