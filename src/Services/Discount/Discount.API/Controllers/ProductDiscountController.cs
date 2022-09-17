using System.Net;
using Discount.Application.Features.ProductDiscounts.Commands.CreateProductDiscount;
using Discount.Application.Features.ProductDiscounts.Commands.DeleteProductDiscount;
using Discount.Application.Features.ProductDiscounts.Commands.UpdateProductDiscount;
using Discount.Application.Features.ProductDiscounts.Queries.GetProductDiscount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers;

[Route("api/v1/[controller]")]
public class ProductDiscountController : ApiController
{
    private readonly ISender _mediator;

    public ProductDiscountController(ISender mediator)
    {
        _mediator = mediator;
    }

    // GET api/v1/[controller]/id
    [HttpGet("{productId}", Name = "GetProductDiscount")]
    [ProducesResponseType(typeof(GetProductDiscountQueryResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductDiscount([FromRoute] Guid productId)
    {
        var result = await _mediator.Send(new GetProductDiscountQuery(productId));
        return Result(result);
    }

    [HttpPost(Name = "CreateProductDiscount")]
    [ProducesResponseType(typeof(CreateProductDiscountCommandResult), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateProductDiscount([FromBody] CreateProductDiscountCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match(
            product => CreatedAtRoute("GetProductDiscount", new { productId = product.ProductDiscount.ProductId }, product),
            errors => Problem(errors));
    }

    [HttpPut(Name = "UpdateProductDiscount")]
    [ProducesResponseType(typeof(UpdateProductDiscountCommandResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateProductDiscount([FromBody] UpdateProductDiscountCommand command)
    {
        var result = await _mediator.Send(command);
        return Result(result);
    }

    [HttpDelete("{productId}", Name = "DeleteProductDiscount")]
    [ProducesResponseType(typeof(DeleteProductDiscountCommandResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteProductDiscount([FromRoute] Guid productId)
    {
        var result = await _mediator.Send(new DeleteProductDiscountCommand(productId));
        return Result(result);
    }
}


