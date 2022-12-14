using AutoMapper;
using EventBus.Messages.Events;
using Orders.Application.Features.Orders.Commands.CheckoutOrder;

namespace Orders.API.Mappings;

public class OrderProfile : Profile
{
	public OrderProfile()
	{
		CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
	}
}
