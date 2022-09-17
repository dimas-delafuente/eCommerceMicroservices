using Common.Primitives.Commands;
using Discount.Domain.Abstractions.Repositories;
using Discount.Domain.Entities;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Commands.CreateProductDiscount;

internal sealed class CreateProductDiscountCommandHandler : ICommandHandler<CreateProductDiscountCommand, ErrorOr<CreateProductDiscountCommandResult>>
{
    private readonly IProductDiscountRepository _productDiscountRepository;

    public CreateProductDiscountCommandHandler(IProductDiscountRepository productDiscountRepository)
    {
        _productDiscountRepository = productDiscountRepository;
    }

    public async Task<ErrorOr<CreateProductDiscountCommandResult>> Handle(CreateProductDiscountCommand request, CancellationToken cancellationToken)
    {
        var productDiscount = ProductDiscount.Create(request.ProductId, request.Description, request.Amount);
        await _productDiscountRepository.CreateAsync(productDiscount);

        return new CreateProductDiscountCommandResult(productDiscount);

    }
}
