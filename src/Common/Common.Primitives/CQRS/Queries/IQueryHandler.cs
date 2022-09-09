using ErrorOr;
using MediatR;

namespace Common.Primitives.Queries;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : IErrorOr
{
}
