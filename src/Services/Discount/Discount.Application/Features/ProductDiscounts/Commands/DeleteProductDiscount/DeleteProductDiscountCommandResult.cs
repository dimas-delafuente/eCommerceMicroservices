using Common.Primitives.Commands;

namespace Discount.Application.Features.ProductDiscounts.Commands.DeleteProductDiscount;

public sealed record DeleteProductDiscountCommandResult(bool Deleted) : ICommandResult;