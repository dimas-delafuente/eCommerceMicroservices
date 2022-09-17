using Common.Primitives.Commands;
using Discount.Domain.Abstractions.Repositories;
using Discount.Domain.Errors;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Commands.DeleteProductDiscount;

internal sealed class DeleteProductDiscountCommandHandler : ICommandHandler<DeleteProductDiscountCommand, ErrorOr<DeleteProductDiscountCommandResult>>
{
    private readonly IProductDiscountRepository _productDiscountRepository;

    public DeleteProductDiscountCommandHandler(IProductDiscountRepository productDiscountRepository)
    {
        _productDiscountRepository = productDiscountRepository;
    }

    public async Task<ErrorOr<DeleteProductDiscountCommandResult>> Handle(DeleteProductDiscountCommand request, CancellationToken cancellationToken)
    {
        var productDiscount = await _productDiscountRepository.GetByProductIdAsync(request.ProductId);

        if (productDiscount is null)
        {
            return Errors.ProductDiscount.NotFound;
        }

        var deleted = await _productDiscountRepository.DeleteIdAsync(productDiscount.Id);

        return new DeleteProductDiscountCommandResult(deleted);
    }
}
