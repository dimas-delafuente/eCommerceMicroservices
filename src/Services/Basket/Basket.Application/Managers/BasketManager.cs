using Basket.Application.Abstractions;
using Basket.Application.Contracts;
using Basket.Domain.Abstractions.Repositories;
using Common.Primitives;
using ErrorOr;

namespace Basket.Application.Managers;

internal class BasketManager : IBasketManager
{
    private readonly IBasketRepository _basketRepository;

    public BasketManager(IBasketRepository basketRepository)
    {
        Ensure.NotNull(basketRepository, nameof(basketRepository));
        _basketRepository = basketRepository;
    }

    public async Task DeleteBasket(Guid basketId)
    {
        await _basketRepository.DeteleAsync(basketId);
    }

    public async Task<ErrorOr<Domain.Entities.Basket>> GetBasket(Guid basketId)
    {
        var basket = await _basketRepository.GetBasketAsync(basketId);
        return basket is null ? new Domain.Entities.Basket(basketId) : basket;
    }

    public async Task<ErrorOr<Domain.Entities.Basket>> SetBasket(CreateBasketCommand basketCommand)
    {
        var basketItems = basketCommand.Items.Select(i => new Domain.Entities.BasketItem(i.ProductId, i.Quantity, i.Price)).ToList();
        var basket = new Domain.Entities.Basket(basketCommand.BasketId, basketItems);
        return await _basketRepository.UpdateBasketAsync(basket);
    }
}
