using Common.Primitives.Queries;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Queries.GetAllProductDiscounts;

public sealed record GetAllProductDiscountsQuery() : IQuery<ErrorOr<GetAllProductDiscountsQueryResult>>;
