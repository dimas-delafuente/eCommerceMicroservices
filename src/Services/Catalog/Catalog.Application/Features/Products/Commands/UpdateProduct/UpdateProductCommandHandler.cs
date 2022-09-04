using Catalog.Application.Abstractions.Commands;
using Catalog.Domain.Abstractions.Repositories;
using Catalog.Domain.Entities;
using Catalog.Domain.Shared;
using Catalog.Domain.Shared.Errors;
using Catalog.Domain.ValueObjects;
using ErrorOr;

namespace Catalog.Application.Features.Products.Commands.UpdateProduct;

internal class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, ErrorOr<UpdateProductCommandResult>>
{
    private readonly IProductsRepository _productsRepository;

    public UpdateProductCommandHandler(IProductsRepository productsRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        this._productsRepository = productsRepository;
    }

    public async Task<ErrorOr<UpdateProductCommandResult>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var currentProduct = await _productsRepository.GetByIdAsync(request.Id);
        if (currentProduct is null)
        {
            return Errors.Product.NotFound;
        }

        var product = Product.Create(request.Id, request.Name, request.Category, request.Summary, request.Description, request.ImageFile, Price.From(request.Price, request.Currency));
        bool updated = await _productsRepository.UpdateProductAsync(product);

        return new UpdateProductCommandResult(updated);
    }
}
