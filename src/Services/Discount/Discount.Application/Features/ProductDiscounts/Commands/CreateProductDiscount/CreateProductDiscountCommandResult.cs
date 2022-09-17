using Common.Primitives.Commands;
using Discount.Domain.Entities;

namespace Discount.Application.Features.ProductDiscounts.Commands.CreateProductDiscount;

public sealed record CreateProductDiscountCommandResult(ProductDiscount ProductDiscount) : ICommandResult;