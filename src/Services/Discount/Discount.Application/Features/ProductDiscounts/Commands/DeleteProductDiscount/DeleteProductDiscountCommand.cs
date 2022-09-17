using Common.Primitives.Commands;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Commands.DeleteProductDiscount;

public sealed record DeleteProductDiscountCommand(Guid ProductId) : ICommand<ErrorOr<DeleteProductDiscountCommandResult>>;