using System.ComponentModel.DataAnnotations;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Features.Orders.Commands.CheckoutOrder;
using Orders.Application.Features.Orders.Commands.DeleteOrder;
using Orders.Application.Features.Orders.Commands.UpdateOrder;
using Orders.Application.Features.Orders.Queries.GetUserOrderList;

namespace Orders.API.Controllers;

[Route("api/v1/[controller]")]
public class OrdersController : ApiController
{
    private readonly ISender _mediator;

    public OrdersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userName}", Name = "GetOrdersByUserName")]
    [ProducesResponseType(typeof(GetUserOrderListQueryResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetProductDiscount([FromRoute, Required] string userName)
    {
        var result = await _mediator.Send(new GetUserOrderListQuery(userName));
        return Result(result);
    }

    [HttpPost(Name = "CheckoutOrder")]
    [ProducesResponseType(typeof(CheckoutOrderCommandResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CheckoutOrder([FromBody] CheckoutOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Result(result);
    }

    [HttpPut(Name = "UpdateOrder")]
    [ProducesResponseType(typeof(UpdateOrderCommandResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Result(result);
    }

    [HttpDelete("{id}", Name = "DeleteOrder")]
    [ProducesResponseType(typeof(DeleteOrderCommandResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var result = await _mediator.Send(new DeleteOrderCommand(id));
        return Result(result);
    }
}
