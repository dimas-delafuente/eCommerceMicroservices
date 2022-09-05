using Catalog.Application.Abstractions.Commands;
using Catalog.Domain.Abstractions.Repositories;
using Catalog.Domain.Shared.Errors;
using Common.Primitives;
using ErrorOr;

namespace Catalog.Application.Features.Products.Commands.DeleteProduct;

internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, ErrorOr<DeleteProductCommandResult>>
{
    private readonly IProductsRepository _productsRepository;

    public DeleteProductCommandHandler(IProductsRepository productsRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        _productsRepository = productsRepository;
    }

    public async Task<ErrorOr<DeleteProductCommandResult>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.Id);
        if (product is null)
        {
            return Errors.Product.NotFound;
        }

        var deleted = await _productsRepository.DeleteAsync(product.Id);
        return new DeleteProductCommandResult(deleted);
    }
}
