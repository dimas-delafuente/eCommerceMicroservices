using Catalog.Application.Abstractions.Commands;
using ErrorOr;

namespace Catalog.Application.Features.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) : ICommand<ErrorOr<DeleteProductCommandResult>>;
