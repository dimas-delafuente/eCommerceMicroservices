using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions.Repositories;

public interface IProductDiscountRepository : IRepository<ProductDiscount>
{
    Task<IEnumerable<ProductDiscount>> GetAllAsync();
    Task<ProductDiscount?> GetByProductIdAsync(Guid productId);
}
