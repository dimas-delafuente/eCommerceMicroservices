using Catalog.Application.Abstractions.Commands;

namespace Catalog.Application.Features.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommandResult(bool Deleted) : ICommandResult;