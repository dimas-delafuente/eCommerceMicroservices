using Basket.Domain.Entities;

namespace Basket.Domain.Abstractions.Repositories;

public interface IProductDiscountRepository
{
    Task<IEnumerable<ProductDiscount>> GetAllAsync();
    Task<ProductDiscount?> GetByProductIdAsync(Guid productId);
}
