using Microsoft.EntityFrameworkCore;
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
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<ShoppingCart> GetShoppingCartByIdAsync(int id)
        {
            var shoppingCart = await _context.ShoppingCarts
                                             .Include(s => s.Items)
                                             .FirstOrDefaultAsync(s => s.Id == id);
            return shoppingCart;
        }

    }
}
