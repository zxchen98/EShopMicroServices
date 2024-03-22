using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.ApplicationCore.Contracts.IService;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Models.RequestModel;
using ProductAPI.ApplicationCore.Models.ResponseModel;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServiceAsync _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryServiceAsync categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            var categoryId = await _categoryService.CreateCategoryAsync(category);
            if (categoryId > 0)
            {
                var categoryResponse = _mapper.Map<CategoryResponse>(category);
                return CreatedAtAction(nameof(GetCategory), new { id = categoryId }, categoryResponse);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category != null)
            {
                var categoryResponse = _mapper.Map<CategoryResponse>(category);
                return Ok(categoryResponse);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var categoryResponses = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return Ok(categoryResponses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            category.Id = id;
            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
