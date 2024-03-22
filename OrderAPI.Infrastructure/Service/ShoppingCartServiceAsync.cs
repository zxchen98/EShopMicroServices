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
    public class ShoppingCartServiceAsync : IShoppingCartServiceAsync
    {
        private readonly IShoppingCartRepositoryAsync _shoppingCartRepository;
        private readonly IShoppingCartItemRepositoryAsync _shoppingCartItemRepository;
        public ShoppingCartServiceAsync(IShoppingCartRepositoryAsync shoppingCartRepository, IShoppingCartItemRepositoryAsync shoppingCartItemRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task<int> CreateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            return await _shoppingCartRepository.InsertAsync(shoppingCart);
        }

        public async Task<int> UpdateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            return await _shoppingCartRepository.UpdateAsync(shoppingCart);
        }

        public async Task<int> DeleteShoppingCartAsync(int shoppingCartId)
        {
            return await _shoppingCartRepository.DeleteAsync(shoppingCartId);
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsAsync()
        {
            return await _shoppingCartRepository.GetAllAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByIdAsync(int shoppingCartId)
        {
            return await _shoppingCartRepository.GetByIdAsync(shoppingCartId);
        }

        public async Task<IEnumerable<ShoppingCart>> FilterShoppingCartsAsync(Expression<Func<ShoppingCart, bool>> filter)
        {
            return await _shoppingCartRepository.Filter(filter);
        }

        public async Task<int> AddItemsToShoppingCartAsync(int shoppingCartId, IEnumerable<ShoppingCartItem> items)
        {
            var shoppingCart = await _shoppingCartRepository.GetByIdAsync(shoppingCartId);
            if (shoppingCart == null)
            {
                throw new KeyNotFoundException("Shopping cart not found.");
            }

            foreach (var item in items)
            {
                var existingItem = shoppingCart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                    await _shoppingCartItemRepository.UpdateAsync(existingItem);
                }
                else
                {
                    item.ShoppingCartId = shoppingCartId;
                    await _shoppingCartItemRepository.InsertAsync(item);
                    shoppingCart.Items.Add(item);
                }
            }

            return shoppingCart.Items.Count;
        }

        public async Task<bool> DecreaseProductQuantityAsync(int shoppingCartId, int productId)
        {
            var shoppingCart = await _shoppingCartRepository.GetByIdAsync(shoppingCartId);
            if (shoppingCart == null)
            {
                throw new KeyNotFoundException("Shopping cart not found.");
            }

            var item = shoppingCart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                throw new KeyNotFoundException("Product not found in the shopping cart.");
            }

            if (item.Quantity > 1)
            {
                item.Quantity -= 1;
                await _shoppingCartItemRepository.UpdateAsync(item);
            }
            else
            {
                await _shoppingCartItemRepository.DeleteAsync(item.Id);
                shoppingCart.Items.Remove(item);
            }


            return true;
        }

    }

}
