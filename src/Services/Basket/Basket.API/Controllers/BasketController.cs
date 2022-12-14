using System.Net;
using Basket.Application.Abstractions;
using Basket.Application.Contracts;
using Common.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[Route("api/v1/[controller]")]
public class BasketController : ApiController
{
    private readonly IBasketManager _basketManager;

    public BasketController(IBasketManager basketManager)
    {
        Ensure.NotNull(basketManager, nameof(basketManager));
        _basketManager = basketManager;
    }

    [HttpGet("{id}", Name = "GetBasket")]
    [ProducesResponseType(typeof(Domain.Entities.Basket), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetBasket([FromRoute] Guid id)
    {
        var result = await _basketManager.GetBasket(id);
        return Result(result);
    }

    [HttpDelete("{id}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteBasket([FromRoute] Guid id)
    {
        await _basketManager.DeleteBasket(id);
        return Ok();
    }

    [HttpPost(Name = "CreateBasket")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> CreateBasket([FromBody] CreateBasketCommand command)
    {
        var result = await _basketManager.SetBasket(command);
        return Result(result);
    }

    [HttpPost("{id}/checkout", Name = "Checkout")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Checkout([FromRoute] Guid id, [FromBody] CheckoutBasketCommand checkoutBasketCommand)
    {
        var result = await _basketManager.Checkout(id, checkoutBasketCommand);
        return Result(result);
    }
}
