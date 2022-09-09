using ErrorOr;
using MediatR;

namespace Common.Primitives.Commands;

public interface ICommand<TCommandResult> : IRequest<TCommandResult>
    where TCommandResult : IErrorOr
{
}
