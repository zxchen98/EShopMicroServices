using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Contracts.IService
{
    public interface IShoppingCartItemServiceAsync
    {
        Task<int> CreateShoppingCartItemAsync(ShoppingCartItem shoppingCartItem);
        Task<int> UpdateShoppingCartItemAsync(ShoppingCartItem shoppingCartItem);
        Task<int> DeleteShoppingCartItemAsync(int shoppingCartItemId);
        Task<IEnumerable<ShoppingCartItem>> GetAllShoppingCartItemsAsync();
        Task<ShoppingCartItem> GetShoppingCartItemByIdAsync(int shoppingCartItemId);
        Task<IEnumerable<ShoppingCartItem>> FilterShoppingCartItemsAsync(Expression<Func<ShoppingCartItem, bool>> filter);
    }
}
