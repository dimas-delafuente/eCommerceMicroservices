using Common.Primitives.Queries;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByName;

public sealed record GetAllProductsByNameQuery(string Name) : IQuery<ErrorOr<GetAllProductsByNameQueryResult>>;
