using Catalog.Domain.Entities;
using Common.Primitives.Queries;

namespace Catalog.Application.Features.Products.Queries.GetProductById;

public sealed record GetProductByIdQueryResult(Product Product) : IQueryResult;
