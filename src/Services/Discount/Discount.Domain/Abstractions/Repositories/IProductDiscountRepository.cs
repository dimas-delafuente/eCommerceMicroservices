using Discount.Domain.Entities;

namespace Discount.Domain.Abstractions.Repositories;

public interface IProductDiscountRepository
{
    Task<IEnumerable<ProductDiscount>> GetAllAsync();
    Task<ProductDiscount?> GetByProductIdAsync(Guid productId);
    Task<bool> CreateAsync(ProductDiscount discount);
    Task<bool> UpdateAsync(ProductDiscount discount);
    Task<bool> DeleteIdAsync(int productId);
}
