using OrderAPI.ApplicationCore.Contracts.IRepository;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Repository
{
    public class ShoppingCartRepositoryAsync : BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepositoryAsync
    {
        public ShoppingCartRepositoryAsync(OrderDbContext tb) : base(tb)
        {
        }

        
    }
}
