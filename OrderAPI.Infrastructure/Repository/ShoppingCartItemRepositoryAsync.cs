using OrderAPI.ApplicationCore.Contracts.IRepository;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Repository
{
    public class ShoppingCartItemRepositoryAsync : BaseRepositoryAsync<ShoppingCartItem>, IShoppingCartItemRepositoryAsync
    {
        public ShoppingCartItemRepositoryAsync(OrderDbContext tb) : base(tb)
        {
        }
    }
}
