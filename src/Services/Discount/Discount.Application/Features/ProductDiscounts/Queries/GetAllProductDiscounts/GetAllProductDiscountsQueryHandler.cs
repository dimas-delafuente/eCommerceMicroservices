using Common.Primitives.Queries;
using Discount.Domain.Abstractions.Repositories;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Queries.GetAllProductDiscounts;

internal sealed class GetAllProductDiscountsQueryHandler : IQueryHandler<GetAllProductDiscountsQuery, ErrorOr<GetAllProductDiscountsQueryResult>>
{
    private readonly IProductDiscountRepository _productDiscountRepository;

    public GetAllProductDiscountsQueryHandler(IProductDiscountRepository productDiscountRepository)
    {
        _productDiscountRepository = productDiscountRepository;
    }

    public async Task<ErrorOr<GetAllProductDiscountsQueryResult>> Handle(GetAllProductDiscountsQuery request, CancellationToken cancellationToken)
    {
        var productDiscounts = await _productDiscountRepository.GetAllAsync();
        return new GetAllProductDiscountsQueryResult(productDiscounts);
    }
}
