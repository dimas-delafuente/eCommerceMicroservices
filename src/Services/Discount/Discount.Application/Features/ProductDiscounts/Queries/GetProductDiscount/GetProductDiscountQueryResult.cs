using Common.Primitives.Queries;
using Discount.Domain.Entities;

namespace Discount.Application.Features.ProductDiscounts.Queries.GetProductDiscount;

public sealed record GetProductDiscountQueryResult(ProductDiscount ProductDiscount) : IQueryResult;