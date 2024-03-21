using ProductAPI.ApplicationCore.Contracts.IRepository;
using ProductAPI.ApplicationCore.Contracts.IService;
using ProductAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Service
{
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync _categoryRepository;

        public CategoryServiceAsync(ICategoryRepositoryAsync categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateCategoryAsync(Category category)
        {
            return await _categoryRepository.InsertAsync(category);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            return category.Id;
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return id;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }
    }

}
