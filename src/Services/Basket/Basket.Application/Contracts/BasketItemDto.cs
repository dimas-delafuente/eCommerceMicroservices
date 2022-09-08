namespace Basket.Application.Contracts;

public sealed record BasketItemDto(Guid ProductId, int Quantity, decimal Price);
