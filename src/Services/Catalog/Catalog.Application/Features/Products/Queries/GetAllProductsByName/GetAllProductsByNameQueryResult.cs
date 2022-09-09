using Catalog.Domain.Entities;
using Common.Primitives.Queries;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByName;

public sealed record GetAllProductsByNameQueryResult(IEnumerable<Product> Products) : IQueryResult;
