using ProductAPI.ApplicationCore.Contracts.IRepository;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Repository
{
    public class CategoryRepositoryAsync : BaseRepositoryAsync<Category>, ICategoryRepositoryAsync
    {
        public CategoryRepositoryAsync(ProductDbContext tb) : base(tb)
        {
        }
    }
}
