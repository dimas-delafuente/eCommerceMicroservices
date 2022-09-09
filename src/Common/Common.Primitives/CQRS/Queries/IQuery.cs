using ErrorOr;
using MediatR;

namespace Common.Primitives.Queries;

public interface IQuery<TQueryResult> : IRequest<TQueryResult>
    where TQueryResult : IErrorOr
{
}
