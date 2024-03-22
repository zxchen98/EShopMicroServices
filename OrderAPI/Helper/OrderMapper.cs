using AutoMapper;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models.RequestModels;
using OrderAPI.ApplicationCore.Models.ResponseModels;

namespace OrderAPI.helper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<OrderRequest, Order>().ReverseMap();

            CreateMap<ShoppingCart, ShoppingCartResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<ShoppingCartRequest, ShoppingCart>();

            CreateMap<ShoppingCartItem, ShoppingCartItemResponse>();
            CreateMap<ShoppingCartItemRequest, ShoppingCartItem>();
        }
    }
}