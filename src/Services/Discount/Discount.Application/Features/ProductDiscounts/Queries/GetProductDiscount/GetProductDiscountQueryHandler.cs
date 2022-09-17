using Common.Primitives.Queries;
using Discount.Domain.Abstractions.Repositories;
using Discount.Domain.Errors;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Queries.GetProductDiscount;

internal sealed class GetProductDiscountQueryHandler : IQueryHandler<GetProductDiscountQuery, ErrorOr<GetProductDiscountQueryResult>>
{
    private readonly IProductDiscountRepository _productDiscountRepository;

    public GetProductDiscountQueryHandler(IProductDiscountRepository productDiscountRepository)
    {
        _productDiscountRepository = productDiscountRepository;
    }

    public async Task<ErrorOr<GetProductDiscountQueryResult>> Handle(GetProductDiscountQuery request, CancellationToken cancellationToken)
    {
        var productDiscount = await _productDiscountRepository.GetByProductIdAsync(request.ProductId);

        if (productDiscount is null)
        {
            return Errors.ProductDiscount.NotFound;
        }

        return new GetProductDiscountQueryResult(productDiscount);
    }
}
