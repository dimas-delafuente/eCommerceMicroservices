using Discount.Application.Features.ProductDiscounts.Commands.CreateProductDiscount;
using Discount.Application.Features.ProductDiscounts.Commands.DeleteProductDiscount;
using Discount.Application.Features.ProductDiscounts.Commands.UpdateProductDiscount;
using Discount.Application.Features.ProductDiscounts.Queries.GetProductDiscount;
using Discount.Grpc.Mappers;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Grpc.Services;

public class ProductDiscountService : ProductDiscountProtoService.ProductDiscountProtoServiceBase
{
    private readonly ISender _mediator;

    public ProductDiscountService(ISender mediator)
    {
        _mediator = mediator;
    }

    public override async Task<ProductDiscount> GetProductDiscount(GetProductDiscountRequest request, ServerCallContext context)
    {
        var result = await _mediator.Send(new GetProductDiscountQuery(Guid.Parse(request.ProductId)));

        return result.IsError
            ? throw new RpcException(new Status(StatusCode.NotFound, result.FirstError.Description))
            : result.Value.ProductDiscount.ToProtoModel();
    }

    public override async Task<ProductDiscount> CreateProductDiscount(CreateProductDiscountRequest request, ServerCallContext context)
    {
        var command = new CreateProductDiscountCommand(Guid.Parse(request.ProductDiscount.ProductId), request.ProductDiscount.Description, Convert.ToDecimal(request.ProductDiscount.Amount));
        var result = await _mediator.Send(command);

        return result.IsError
            ? throw new RpcException(new Status(StatusCode.Internal, result.FirstError.Description))
            : result.Value.ProductDiscount.ToProtoModel();
    }

    public override async Task<ProductDiscount> UpdateProductDiscount(UpdateProductDiscountRequest request, ServerCallContext context)
    {
        var command = new UpdateProductDiscountCommand(Guid.Parse(request.ProductDiscount.ProductId), request.ProductDiscount.Description, Convert.ToDecimal(request.ProductDiscount.Amount));
        var result = await _mediator.Send(command);

        return result.IsError
            ? throw new RpcException(new Status(StatusCode.Internal, result.FirstError.Description))
            : request.ProductDiscount;
    }

    public override async Task<DeleteProductDiscountResponse> DeleteProductDiscount(DeleteProductDiscountRequest request, ServerCallContext context)
    {
        var command = new DeleteProductDiscountCommand(Guid.Parse(request.ProductId));
        var result = await _mediator.Send(command);

        return result.IsError
            ? throw new RpcException(new Status(StatusCode.Internal, result.FirstError.Description))
            : new DeleteProductDiscountResponse
            {
                Deleted = result.Value.Deleted
            };
    }
}
