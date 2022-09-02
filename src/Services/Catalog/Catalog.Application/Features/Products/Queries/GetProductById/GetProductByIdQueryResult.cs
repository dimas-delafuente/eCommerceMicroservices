using Catalog.Application.Abstractions.Queries;
using Catalog.Domain.Entities;

namespace Catalog.Application.Features.Products.Queries.GetProductById;

public sealed record GetProductByIdQueryResult(Product Product) : IQueryResult;
