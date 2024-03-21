using ProductAPI.ApplicationCore.Contracts.IRepository;
using ProductAPI.ApplicationCore.Contracts.IService;
using ProductAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Service
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync _productRepository;

        public ProductServiceAsync(IProductRepositoryAsync productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            return await _productRepository.InsertAsync(product);
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return product.Id;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
            return id;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> FilterProductsAsync(Expression<Func<Product, bool>> filter)
        {
            return await _productRepository.Filter(filter);
        }
    }

}
