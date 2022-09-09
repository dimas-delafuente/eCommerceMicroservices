using Catalog.Domain.Entities;
using Common.Primitives.Commands;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommandResult(Product Product) : ICommandResult;
