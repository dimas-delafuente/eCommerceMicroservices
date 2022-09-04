using Catalog.Application.Abstractions.Commands;
using Catalog.Domain.Entities;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommandResult(Product Product) : ICommandResult;
