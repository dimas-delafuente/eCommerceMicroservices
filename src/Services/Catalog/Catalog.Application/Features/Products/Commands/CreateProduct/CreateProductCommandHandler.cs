using Catalog.Domain.Abstractions.Repositories;
using Catalog.Domain.Entities;
using Common.Primitives;
using Common.Primitives.Commands;
using Common.Primitives.ValueObjects;
using ErrorOr;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ErrorOr<CreateProductCommandResult>>
{
    private readonly IProductsRepository _productsRepository;

    public CreateProductCommandHandler(IProductsRepository productsRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        _productsRepository = productsRepository;
    }

    public async Task<ErrorOr<CreateProductCommandResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(
            request.Name,
            request.Category,
            request.Summary,
            request.Description,
            request.ImageFile,
            Price.From(request.Price, request.Currency));

        await _productsRepository.CreateProductAsync(product);

        return new CreateProductCommandResult(product);
    }
}
