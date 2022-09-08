namespace Basket.Application.Contracts;

public sealed record CreateBasketCommand(Guid BasketId, BasketItemDto[] Items);
