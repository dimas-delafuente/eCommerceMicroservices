using Catalog.Application.Abstractions.Commands;
using ErrorOr;

namespace Catalog.Application.Features.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(Guid Id, string Name, string Category, string Summary, string Description, string ImageFile, decimal Price, string Currency) : ICommand<ErrorOr<UpdateProductCommandResult>>;
