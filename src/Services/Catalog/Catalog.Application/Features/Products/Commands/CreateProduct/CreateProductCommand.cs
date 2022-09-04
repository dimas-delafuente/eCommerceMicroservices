using Catalog.Application.Abstractions.Commands;
using ErrorOr;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, string Category, string Summary, string Description, string ImageFile, decimal Price, string Currency) : ICommand<ErrorOr<CreateProductCommandResult>>;