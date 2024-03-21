using AutoMapper;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Models.RequestModel;
using ProductAPI.ApplicationCore.Models.ResponseModel;

namespace ProductAPI.helper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<ProductRequest, Product>().ReverseMap();

            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<CategoryRequest, Category>().ReverseMap();

            CreateMap<Review, ReviewResponse>().ReverseMap();
            CreateMap<ReviewRequest, Review>().ReverseMap();
        }
    }
}
