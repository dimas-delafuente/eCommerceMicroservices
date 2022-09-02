using ErrorOr;
using MediatR;

namespace Catalog.Application.Abstractions.Queries;

internal interface IQuery<TQueryResult> : IRequest<TQueryResult>
    where TQueryResult : IErrorOr
{
}
