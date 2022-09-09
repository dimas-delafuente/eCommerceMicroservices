using Common.Primitives.Queries;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts;

// TODO: Add name and category. Convert to Specification pattern.
public sealed record GetAllProductsQuery : IQuery<ErrorOr<GetAllProductsQueryResult>>;
