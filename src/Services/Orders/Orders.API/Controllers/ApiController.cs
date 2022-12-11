using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Orders.API.Http;

namespace Orders.API.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Result<TResult>(ErrorOr<TResult> result)
    {
        return result.Match(
            product => Ok(product),
            errors => Problem(errors));
    }

    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }

        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return Problem(errors.First());
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var errorDictionary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            errorDictionary.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(errorDictionary);
    }
}