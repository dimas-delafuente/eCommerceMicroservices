using ErrorOr;
using MediatR;

namespace Common.Primitives.Commands;

public interface ICommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult>
    where TCommandResult : IErrorOr
{
}
