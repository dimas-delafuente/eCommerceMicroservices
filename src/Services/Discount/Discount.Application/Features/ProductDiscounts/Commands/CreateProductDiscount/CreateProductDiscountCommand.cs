using Common.Primitives.Commands;
using ErrorOr;

namespace Discount.Application.Features.ProductDiscounts.Commands.CreateProductDiscount;

public sealed record CreateProductDiscountCommand(Guid ProductId, string Description, decimal Amount) : ICommand<ErrorOr<CreateProductDiscountCommandResult>>;
