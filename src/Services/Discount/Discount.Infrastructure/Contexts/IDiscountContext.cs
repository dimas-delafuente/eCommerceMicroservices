using System.Data;

namespace Discount.Infrastructure.Contexts;

internal interface IDiscountContext
{
    public IDbConnection CreateConnection();
}
