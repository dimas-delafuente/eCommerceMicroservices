using Common.Primitives.Commands;

namespace Discount.Application.Features.ProductDiscounts.Commands.UpdateProductDiscount;

public sealed record UpdateProductDiscountCommandResult(bool Updated) : ICommandResult;