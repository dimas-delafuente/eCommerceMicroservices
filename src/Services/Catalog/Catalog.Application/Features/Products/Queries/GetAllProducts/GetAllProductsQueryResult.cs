using Catalog.Application.Abstractions.Queries;
using Catalog.Domain.Entities;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQueryResult(IEnumerable<Product> Products) : IQueryResult;
