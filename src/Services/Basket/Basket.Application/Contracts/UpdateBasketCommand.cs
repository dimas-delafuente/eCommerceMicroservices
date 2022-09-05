namespace Basket.Application.Contracts;

public sealed record UpdateBasketCommand(Guid BasketId, BasketItemDto[] Items);
