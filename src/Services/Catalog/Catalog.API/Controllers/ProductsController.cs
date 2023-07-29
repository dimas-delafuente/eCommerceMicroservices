using System.Net;
using Catalog.API.Contracts;
using Catalog.Application.Features.Products.Commands.CreateProduct;
using Catalog.Application.Features.Products.Commands.DeleteProduct;
using Catalog.Application.Features.Products.Commands.UpdateProduct;
using Catalog.Application.Features.Products.Queries.GetAllProducts;
using Catalog.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/v1/[controller]")]
public class ProductsController : ApiController
{
    private readonly ISender _mediator;

    public ProductsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetProducts")]
    [ProducesResponseType(typeof(GetAllProductsQueryResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query)
    {
        var result = await _mediator.Send(query);
        return Result(result);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    [ProducesResponseType(typeof(GetProductByIdQueryResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        return Result(result);
    }

    [HttpPost(Name = "CreateProduct")]
    [ProducesResponseType(typeof(CreateProductCommandResult), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateProduct(
        [FromBody] CreateProductRequest request,
        [FromHeader(Name = "X-Idempotency-Key")] string requestId)
    {
        if (!Guid.TryParse(requestId, out var parsedId))
        {
            return BadRequest();
        }

        var command = new CreateProductCommand(
            parsedId,
            request.Name,
            request.Category,
            request.Summary,
            request.Description,
            request.ImageFile,
            request.Price,
            request.Currency);

        var result = await _mediator.Send(command);
        return result.Match(
            product => Created("", null), //TODO: Find a way to retrieve the idempotent response so we can get the Id
            errors => Problem(errors));
    }

    [HttpPut(Name = "UpdateProduct")]
    [ProducesResponseType(typeof(UpdateProductCommandResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Result(result);
    }

    [HttpDelete("{id}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(DeleteProductCommandResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));
        return Result(result);
    }
}
