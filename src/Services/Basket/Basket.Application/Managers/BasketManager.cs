using Basket.Application.Abstractions;
using Basket.Application.Contracts;
using Basket.Domain.Abstractions.Repositories;
using Basket.Domain.Errors;
using Common.Primitives;
using ErrorOr;
using EventBus.Core.Services;
using Microsoft.Extensions.Logging;

namespace Basket.Application.Managers;

internal class BasketManager : IBasketManager
{
    private readonly IBasketRepository _basketRepository;
    private readonly IProductDiscountRepository _discountRepository;
    private readonly IEventBus _eventBus;
    private readonly ILogger<BasketManager> _logger;

    public BasketManager(
        IBasketRepository basketRepository,
        IProductDiscountRepository discountRepository,
        IEventBus eventBus,
        ILogger<BasketManager> logger)
    {
        Ensure.NotNull(basketRepository, nameof(basketRepository));
        Ensure.NotNull(discountRepository, nameof(discountRepository));
        Ensure.NotNull(eventBus, nameof(eventBus));
        Ensure.NotNull(logger, nameof(logger));

        _basketRepository = basketRepository;
        _discountRepository = discountRepository;
        _eventBus = eventBus;
        _logger = logger;
    }

    public async Task<ErrorOr<Domain.Entities.Basket>> Checkout(Guid basketId, CheckoutBasketCommand checkoutBasketCommand)
    {
        var basket = await _basketRepository.GetBasketAsync(basketId);
        if (basket is null)
        {
            return Errors.Basket.NotFound;
        }

        if (basket.Items.Count == 0)
        {
            return Errors.Basket.Empty;
        }

        var eventMessage = checkoutBasketCommand.ToIntegrationEvent(basket.TotalPrice);
        await _eventBus.Publish(eventMessage);

        await DeleteBasket(basketId);

        return basket;
    }

    public async Task DeleteBasket(Guid basketId)
    {
        await _basketRepository.DeleteAsync(basketId);
    }

    public async Task<ErrorOr<Domain.Entities.Basket>> GetBasket(Guid basketId)
    {
        var basket = await _basketRepository.GetBasketAsync(basketId);
        return basket is null ? new Domain.Entities.Basket(basketId) : basket;
    }

    public async Task<ErrorOr<Domain.Entities.Basket>> SetBasket(CreateBasketCommand basketCommand)
    {
        var basketItems = basketCommand.Items.Select(i => new Domain.Entities.BasketItem(i.ProductId, i.Quantity, i.Price)).ToList();
        var basket = new Domain.Entities.Basket(basketCommand.BasketId);
        basket.SetItems(basketItems);

        foreach (var item in basket.Items)
        {
            var productDiscount = await _discountRepository.GetByProductIdAsync(item.ProductId);
            if (productDiscount is not null)
            {
                item.ApplyDiscount(productDiscount.Amount);
            }
        }

        var result = await _basketRepository.UpdateBasketAsync(basket);

        _logger.LogInformation("New basket created. Id {basketId}.", basket.Id);

        return basket;
    }
}
