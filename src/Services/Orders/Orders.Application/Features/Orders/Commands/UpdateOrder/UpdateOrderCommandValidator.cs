using FluentValidation;
using Orders.Application.Features.Orders.Commands.UpdateOrder;

namespace Orders.Application.Features.Orders.Commands.CheckoutOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotNull().WithMessage("{Id} is required.");

        RuleFor(p => p.EmailAddress)
            .NotEmpty()
            .WithMessage("{EmailAddress} is required.")
            .EmailAddress();   
    }
}
