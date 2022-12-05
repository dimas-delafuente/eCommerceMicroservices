using Common.Primitives.Queries;
using Discount.Domain.Entities;

namespace Discount.Application.Features.ProductDiscounts.Queries.GetAllProductDiscounts;

public sealed record GetAllProductDiscountsQueryResult(IEnumerable<ProductDiscount> ProductDiscounts) : IQueryResult;