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
    public class ProductsController : ControllerBase
    {
        private readonly IProductServiceAsync _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductServiceAsync productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            var productId = await _productService.CreateProductAsync(product);
            if (productId > 0)
            {
                var productResponse = _mapper.Map<ProductResponse>(product);
                return CreatedAtAction(nameof(GetProduct), new { id = productId }, productResponse);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product != null)
            {
                var productResponse = _mapper.Map<ProductResponse>(product);
                return Ok(productResponse);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            var productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return Ok(productResponses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            product.Id = id;
            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
