using Common.Primitives;
using Common.Primitives.Queries;
using ErrorOr;
using Orders.Domain.Abstractions.Repositories;

namespace Orders.Application.Features.Orders.Queries.GetUserOrderList;

internal sealed class GetUserOrderListQueryHandler : IQueryHandler<GetUserOrderListQuery, ErrorOr<GetUserOrderListQueryResult>>
{
    private readonly IOrderRepository _orderRepository;

    public GetUserOrderListQueryHandler(IOrderRepository orderRepository)
    {
        Ensure.NotNull(orderRepository, nameof(orderRepository));
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<GetUserOrderListQueryResult>> Handle(GetUserOrderListQuery request, CancellationToken cancellationToken)
    {
        var userOrders = await _orderRepository.GetByUserName(request.UserName);
        return new GetUserOrderListQueryResult(userOrders);
    }
}
