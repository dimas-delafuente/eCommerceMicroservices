using System.Net;
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
    public async Task<IActionResult> GetAllProducts(GetAllProductsQuery query)
    {
        var result = await _mediator.Send(query);

        return result.Match(
            products => Ok(products),
            errors => Problem(errors));
    }

    // GET api/v1/[controller]/id
    [HttpGet("{id}", Name = "GetProduct")]
    [ProducesResponseType(typeof(GetProductByIdQueryResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));

        return result.Match(
            product => Ok(product),
            errors => Problem(errors));
    }
}
