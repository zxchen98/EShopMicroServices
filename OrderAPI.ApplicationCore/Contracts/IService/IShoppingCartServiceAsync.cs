using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Contracts.IService
{
    public interface IShoppingCartServiceAsync
    {
        Task<int> CreateShoppingCartAsync(ShoppingCart shoppingCart);
        Task<int> UpdateShoppingCartAsync(ShoppingCart shoppingCart);
        Task<int> DeleteShoppingCartAsync(int shoppingCartId);
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsAsync();
        Task<ShoppingCart> GetShoppingCartByIdAsync(int shoppingCartId);
        Task<IEnumerable<ShoppingCart>> FilterShoppingCartsAsync(Expression<Func<ShoppingCart, bool>> filter);

        Task<int> AddItemsToShoppingCartAsync(int shoppingCartId, IEnumerable<ShoppingCartItem> items);

        Task<bool> DecreaseProductQuantityAsync(int shoppingCartId, int productId);
    }
}