using Common.Primitives;
using Dapper;
using Discount.Domain.Abstractions.Repositories;
using Discount.Domain.Entities;
using Discount.Infrastructure.Contexts;
using Discount.Infrastructure.DatabaseQueries;

namespace Discount.Infrastructure.Repositories;

internal class ProductDiscountRepository : IProductDiscountRepository
{
    private readonly IDiscountContext _discountContext;

    public ProductDiscountRepository(IDiscountContext discountContext)
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

        var result = await connection.ExecuteAsync(Query.ProductDiscount.Create, dbParams);

        return result > 0;
    }

    public async Task<bool> DeleteIdAsync(int id)
    {
        using var connection = _discountContext.CreateConnection();
        var dbParams = new { Id = id };
        var result = await connection.ExecuteAsync(Query.ProductDiscount.Delete, dbParams);
        return result > 0;
    }

    public async Task<ProductDiscount?> GetByProductIdAsync(Guid productId)
    {
        using var connection = _discountContext.CreateConnection();
        var dbParams = new { ProductId = productId };
        return await connection
            .QueryFirstOrDefaultAsync<ProductDiscount>(Query.ProductDiscount.Get, dbParams);
    }

    public async Task<IEnumerable<ProductDiscount>> GetAllAsync()
    {
        using var connection = _discountContext.CreateConnection();
        return await connection.QueryAsync<ProductDiscount>(Query.ProductDiscount.GetAll);
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
