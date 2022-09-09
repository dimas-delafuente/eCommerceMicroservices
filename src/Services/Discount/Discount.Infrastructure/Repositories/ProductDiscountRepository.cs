using Common.Primitives;
using Dapper;
using Discount.Domain.Abstractions.Repositories;
using Discount.Domain.Entities;
using Discount.Infrastructure.Contexts;
using Discount.Infrastructure.DatabaseQueries;

namespace Discount.Infrastructure.Repositories;

internal class ProductDiscountRepository : IProductDiscountRepository
{
    private readonly DiscountContext _discountContext;

    public ProductDiscountRepository(DiscountContext discountContext)
    {
        Ensure.NotNull(discountContext, nameof(discountContext));
        _discountContext = discountContext;
    }

    public async Task<bool> CreateAsync(ProductDiscount discount)
    {
        using var connection = _discountContext.CreateConnection();
        var dbParams = new
        {
            discount.ProductId,
            discount.Description,
            discount.Amount
        };

        var result = await connection.ExecuteAsync(Query.ProductDiscount.Get, dbParams);

        return result > 0;
    }

    public async Task<bool> DeleteByProductIdAsync(Guid productId)
    {
        using var connection = _discountContext.CreateConnection();
        var dbParams = new { ProductId = productId };
        var result = await connection.ExecuteAsync(Query.ProductDiscount.Create, dbParams);
        return result > 0;
    }

    public async Task<ProductDiscount?> GetByProductIdAsync(Guid productId)
    {
        using var connection = _discountContext.CreateConnection();
        var dbParams = new { ProductId = productId };
        return await connection
            .QueryFirstOrDefaultAsync<ProductDiscount>(Query.ProductDiscount.Delete, dbParams);
    }

    public async Task<bool> UpdateAsync(ProductDiscount discount)
    {
        using var connection = _discountContext.CreateConnection();
        var dbParams = new
        {
            discount.Id,
            discount.ProductId,
            discount.Description,
            discount.Amount
        };

        var result = await connection.ExecuteAsync(Query.ProductDiscount.Update, dbParams);

        return result > 0;
    }
}
