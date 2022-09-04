using Catalog.Domain.Enumerations;
using FluentValidation;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Category).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Summary).NotEmpty();
        RuleFor(c => c.ImageFile).NotEmpty();
        RuleFor(c => c.Price).GreaterThan(0);
        RuleFor(c => c.Currency).NotEmpty().Must(currency => Currency.Values.Any(v => v.Name == currency))
            .WithMessage("Invalid currency.");
    }
}
