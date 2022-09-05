using Basket.Application.Abstractions;
using Basket.Application.Contracts;
using Basket.Domain.Abstractions.Repositories;
using Basket.Domain.Errors;
using Common.Primitives;
using Common.Primitives.ValueObjects;
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
        return basket is null ? Errors.Basket.NotFound : basket;
    }

    public async Task<ErrorOr<Domain.Entities.Basket>> UpdateBasket(UpdateBasketCommand basketCommand)
    {
        var basketItems = basketCommand.Items.Select(i => new Domain.Entities.BasketItem(i.ProductId, i.Quantity, Price.From(i.Price, i.Currency))).ToList();
        var basket = new Domain.Entities.Basket(basketCommand.BasketId, basketItems);
        return await _basketRepository.UpdateBasketAsync(basket);
    }
}
