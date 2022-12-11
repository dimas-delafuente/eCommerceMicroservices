using Common.Primitives.Queries;
using Orders.Domain.Entities;

namespace Orders.Application.Features.Orders.Queries.GetUserOrderList;

public sealed record GetUserOrderListQueryResult(IEnumerable<Order> Orders) : IQueryResult;