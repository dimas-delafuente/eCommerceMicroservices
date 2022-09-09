using Common.Primitives.Queries;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ErrorOr<GetProductByIdQueryResult>>;
