using Catalog.Domain.Entities;
using Common.Primitives.Queries;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQueryResult(IEnumerable<Product> Products) : IQueryResult;
