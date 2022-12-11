using Orders.Domain.Abstractions.Repositories;
using Orders.Domain.Entities;
using Orders.Infrastructure.Contexts;

namespace Orders.Infrastructure.Repositories;

internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrdersContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Order>> GetByUserName(string userName)
    {
        return await GetAsync(order => order.UserName == userName);
    }
}
