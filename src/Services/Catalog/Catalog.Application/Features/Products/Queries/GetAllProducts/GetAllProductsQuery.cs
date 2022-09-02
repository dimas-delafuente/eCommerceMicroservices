using Catalog.Application.Abstractions.Queries;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery : IQuery<ErrorOr<GetAllProductsQueryResult>>;
