using Common.Primitives.Queries;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Queries.GetProductDiscount;

public sealed record GetProductDiscountQuery(Guid ProductId) : IQuery<ErrorOr<GetProductDiscountQueryResult>>;