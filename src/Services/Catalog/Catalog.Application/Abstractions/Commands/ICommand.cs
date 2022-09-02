using ErrorOr;
using MediatR;

namespace Catalog.Application.Abstractions.Commands;

internal interface ICommand<TCommandResult> : IRequest<TCommandResult>
    where TCommandResult : IErrorOr
{
}
