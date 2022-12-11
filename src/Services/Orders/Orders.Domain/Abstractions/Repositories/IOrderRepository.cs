using Orders.Domain.Entities;

namespace Orders.Domain.Abstractions.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetByUserName(string userName);
}
