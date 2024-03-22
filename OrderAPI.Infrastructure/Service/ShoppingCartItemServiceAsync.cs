using OrderAPI.ApplicationCore.Contracts.IRepository;
using OrderAPI.ApplicationCore.Contracts.IService;
using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Service
{
    public class ShoppingCartItemServiceAsync : IShoppingCartItemServiceAsync
    {
        private readonly IShoppingCartItemRepositoryAsync _shoppingCartItemRepository;

        public ShoppingCartItemServiceAsync(IShoppingCartItemRepositoryAsync shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task<int> CreateShoppingCartItemAsync(ShoppingCartItem shoppingCartItem)
        {
            return await _shoppingCartItemRepository.InsertAsync(shoppingCartItem);
        }

        public async Task<int> UpdateShoppingCartItemAsync(ShoppingCartItem shoppingCartItem)
        {
            return await _shoppingCartItemRepository.UpdateAsync(shoppingCartItem);
        }

        public async Task<int> DeleteShoppingCartItemAsync(int shoppingCartItemId)
        {
            return await _shoppingCartItemRepository.DeleteAsync(shoppingCartItemId);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetAllShoppingCartItemsAsync()
        {
            return await _shoppingCartItemRepository.GetAllAsync();
        }

        public async Task<ShoppingCartItem> GetShoppingCartItemByIdAsync(int shoppingCartItemId)
        {
            return await _shoppingCartItemRepository.GetByIdAsync(shoppingCartItemId);
        }

        public async Task<IEnumerable<ShoppingCartItem>> FilterShoppingCartItemsAsync(Expression<Func<ShoppingCartItem, bool>> filter)
        {
            return await _shoppingCartItemRepository.Filter(filter);
        }
    }

}
