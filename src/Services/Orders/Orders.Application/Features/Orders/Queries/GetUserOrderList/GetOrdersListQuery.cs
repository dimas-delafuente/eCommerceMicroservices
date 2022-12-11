using Common.Primitives.Queries;
using ErrorOr;

namespace Orders.Application.Features.Orders.Queries.GetUserOrderList;

public sealed record GetUserOrderListQuery(string UserName) : IQuery<ErrorOr<GetUserOrderListQueryResult>>;
