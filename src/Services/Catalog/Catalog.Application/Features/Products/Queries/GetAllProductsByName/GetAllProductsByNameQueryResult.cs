using Catalog.Application.Abstractions.Queries;
using Catalog.Domain.Entities;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByName;

public sealed record GetAllProductsByNameQueryResult(IEnumerable<Product> Products) : IQueryResult;
