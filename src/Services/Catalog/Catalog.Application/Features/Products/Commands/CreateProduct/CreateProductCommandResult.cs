using Common.Primitives.Commands;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommandResult(Guid ProductId) : ICommandResult;
