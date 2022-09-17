using Common.Primitives.Commands;
using Discount.Domain.Abstractions.Repositories;
using Discount.Domain.Entities;
using Discount.Domain.Errors;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Commands.UpdateProductDiscount;

internal sealed class UpdateProductDiscountCommandHandler : ICommandHandler<UpdateProductDiscountCommand, ErrorOr<UpdateProductDiscountCommandResult>>
{
    private readonly IProductDiscountRepository _productDiscountRepository;

    public UpdateProductDiscountCommandHandler(IProductDiscountRepository productDiscountRepository)
    {
        _productDiscountRepository = productDiscountRepository;
    }

    public async Task<ErrorOr<UpdateProductDiscountCommandResult>> Handle(UpdateProductDiscountCommand request, CancellationToken cancellationToken)
    {
        var currentProductDiscount = await _productDiscountRepository.GetByProductIdAsync(request.ProductId);
        if (currentProductDiscount is null)
        {
            return Errors.ProductDiscount.NotFound;
        }

        var productDiscount = ProductDiscount.Create(currentProductDiscount.Id, request.ProductId, request.Description, request.Amount);
        var updated = await _productDiscountRepository.UpdateAsync(productDiscount);

        return new UpdateProductDiscountCommandResult(updated);
    }
}
