using Basket.Application.Contracts;
using ErrorOr;

namespace Basket.Application.Abstractions;

public interface IBasketManager
{
    Task<ErrorOr<Domain.Entities.Basket>> GetBasket(Guid basketId);
    Task<ErrorOr<Domain.Entities.Basket>> SetBasket(CreateBasketCommand basket);
    Task DeleteBasket(Guid basketId);
    Task<ErrorOr<Domain.Entities.Basket>> Checkout(Guid basketId);
}
