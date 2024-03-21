using ProductAPI.ApplicationCore.Contracts.IRepository;
using ProductAPI.ApplicationCore.Contracts.IService;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Repository
{
    public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(ProductDbContext tb) : base(tb)
        {
        }
    }
}
