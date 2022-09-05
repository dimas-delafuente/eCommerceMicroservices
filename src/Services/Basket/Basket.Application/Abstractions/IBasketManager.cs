using Basket.Application.Contracts;
using ErrorOr;

namespace Basket.Application.Abstractions;

public interface IBasketManager
{
    Task<ErrorOr<Domain.Entities.Basket>> GetBasket(Guid basketId);
    Task<ErrorOr<Domain.Entities.Basket>> UpdateBasket(UpdateBasketCommand basket);
    Task DeleteBasket(Guid basketId);
}
