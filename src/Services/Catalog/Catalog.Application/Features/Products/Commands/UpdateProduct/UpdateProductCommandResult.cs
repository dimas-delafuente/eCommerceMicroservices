using Catalog.Application.Abstractions.Commands;

namespace Catalog.Application.Features.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommandResult(bool Updated) : ICommandResult;