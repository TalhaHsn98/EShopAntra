using AutoMapper;
using OrderService.DTO;
using OrderService.Models;

namespace OrderService.Mapping
{

    public class OrderServiceProfile : Profile
    {
        public OrderServiceProfile()
        {
            CreateMap<ShoppingCartCreateRequest, ShoppingCart>();
            CreateMap<ShoppingCartItemRequest, ShoppingCartItem>();
            CreateMap<ShoppingCart, ShoppingCartResponse>();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponse>();
        }
    }
}
