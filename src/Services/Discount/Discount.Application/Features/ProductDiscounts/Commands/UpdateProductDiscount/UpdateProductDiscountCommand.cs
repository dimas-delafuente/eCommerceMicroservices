using Common.Primitives.Commands;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Commands.UpdateProductDiscount;

public sealed record UpdateProductDiscountCommand(Guid ProductId, string Description, decimal Amount) : ICommand<ErrorOr<UpdateProductDiscountCommandResult>>;