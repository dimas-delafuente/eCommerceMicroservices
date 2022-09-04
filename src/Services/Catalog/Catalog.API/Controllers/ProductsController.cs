using System.Net;
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

    // GET api/v1/[controller]
    [HttpGet(Name = "GetProducts")]
    [ProducesResponseType(typeof(GetAllProductsQueryResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query)
    {
        var result = await _mediator.Send(query);
        return Result(result);
    }

    // GET api/v1/[controller]/id
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
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match(
            product => CreatedAtRoute("GetProduct", new { id = product.Product.Id }, product),
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
