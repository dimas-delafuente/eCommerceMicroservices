using ErrorOr;
using MediatR;

namespace Catalog.Application.Abstractions.Queries;

internal interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : IErrorOr
{
}
