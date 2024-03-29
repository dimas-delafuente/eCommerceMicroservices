﻿using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Orders.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator == null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        return TryCreateErrorResponseFromErrors(validationResult.Errors, out var errorResponse)
            ? errorResponse
            : throw new ValidationException(validationResult.Errors);
    }

    private static bool TryCreateErrorResponseFromErrors(List<ValidationFailure> validationFailures, out TResponse errorResponse)
    {
        List<Error> errors = validationFailures
            .ConvertAll(x => Error.Validation(code: x.PropertyName, description: x.ErrorMessage));

        try
        {
            errorResponse = (TResponse)(dynamic)errors;
            return true;
        }
        catch
        {
            errorResponse = default!;
            return false;
        }
    }
}
