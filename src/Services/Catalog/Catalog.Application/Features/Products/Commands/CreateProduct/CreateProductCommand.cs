using Common.Idempotency;
using ErrorOr;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    Guid RequestId,
    string Name,
    string Category,
    string Summary,
    string Description,
    string ImageFile,
    decimal Price,
    string Currency) : IdempotentCommand<ErrorOr<CreateProductCommandResult>>(RequestId);