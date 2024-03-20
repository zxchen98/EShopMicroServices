using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using AutoMapper;

namespace CustomerAPI.Helper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            CreateMap<CustomerRequest, Customer>().ReverseMap();
        }
    }
}
