using AutoMapper;
using OrderService.DTO;
using OrderService.Models;

namespace OrderService.Mapping
{

    public class OrderServiceProfile : Profile
    {
        public void AddCustomerMaps()
        {
            CreateMap<AddressRequest, Address>();
            CreateMap<Address, CustomerAddressResponse>()
                .ForMember(d => d.AddressId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.IsDefaultAddress, opt => opt.Ignore());
        }

        public OrderServiceProfile()
        {
            AddCustomerMaps();
            CreateMap<ShoppingCartCreateRequest, ShoppingCart>();
            CreateMap<ShoppingCartItemRequest, ShoppingCartItem>();
            CreateMap<ShoppingCart, ShoppingCartResponse>();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponse>();

            CreateMap<OrderDetailRequest, OrderDetail>();
            CreateMap<OrderCreateRequest, Order>();
            CreateMap<OrderUpdateRequest, Order>();
            CreateMap<OrderDetail, OrderDetailResponse>();
            CreateMap<Order, OrderResponse>()
                .ForMember(d => d.OrderDate, opt => opt.MapFrom(s => s.OrderDate.ToString("O")));

            CreateMap<PaymentTypeRequest, PaymentType>();
            CreateMap<PaymentType, PaymentTypeResponse>();
            CreateMap<PaymentMethodRequest, PaymentMethod>();
            CreateMap<PaymentMethod, PaymentMethodResponse>()
                .ForMember(d => d.PaymentTypeName, opt => opt.MapFrom(s => s.PaymentType.Name));
        }
    }
}
