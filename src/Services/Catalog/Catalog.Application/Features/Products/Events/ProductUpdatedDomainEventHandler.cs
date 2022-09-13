using Catalog.Domain.Abstractions.Repositories;
using Catalog.Domain.Events;
using Common.Primitives;
using Common.Primitives.CQRS.Events;

namespace Catalog.Application.Features.Products.Events;

internal sealed class ProductUpdatedDomainEventHandler : IDomainEventHandler<ProductUpdatedDomainEvent>
{
    private readonly IProductsRepository _productsRepository;

    public ProductUpdatedDomainEventHandler(IProductsRepository productsRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        _productsRepository = productsRepository;
    }

    public async Task Handle(ProductUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(notification.ProductId);

        if (product is not null)
        {
            Console.WriteLine(notification);
        }
    }
}
