using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Infrastructure.Data
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
