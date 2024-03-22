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

            CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
            CreateMap<ShoppingCartRequest, ShoppingCart>().ReverseMap();

            CreateMap<ShoppingCartItem, ShoppingCartItemResponse>().ReverseMap();
            CreateMap<ShoppingCartItemRequest, ShoppingCartItem>().ReverseMap();
        }
    }
}