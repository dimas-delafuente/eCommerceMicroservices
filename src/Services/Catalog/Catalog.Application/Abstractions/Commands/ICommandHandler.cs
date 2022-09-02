using ErrorOr;
using MediatR;

namespace Catalog.Application.Abstractions.Commands;

internal interface ICommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult>
    where TCommandResult : IErrorOr
{
}
