namespace Basket.Domain.Abstractions.Repositories;

public interface IBasketRepository
{
    Task<Entities.Basket?> GetBasketAsync(Guid id);
    Task<Entities.Basket> UpdateBasketAsync(Entities.Basket cart);
    Task DeteleAsync(Guid id);
}
