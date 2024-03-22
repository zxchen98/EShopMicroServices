using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.IService;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models.RequestModels;
using OrderAPI.ApplicationCore.Models.ResponseModels;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartServiceAsync _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartServiceAsync shoppingCartService, IMapper mapper)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingCart()
        {
            var shoppingCart = new ShoppingCart
            {
                Items = new List<ShoppingCartItem>(),
                Price = 0,
                OrderDate = DateTime.Now,
                OrderStatus = "Processing"
            };

            var _shoppingCartId = await _shoppingCartService.CreateShoppingCartAsync(shoppingCart);

            if (_shoppingCartId > 0)
            {

                return CreatedAtAction(nameof(GetShoppingCart), new { shoppingCartId = _shoppingCartId }, _shoppingCartId);
            }

            return BadRequest("Failed to create the shopping cart.");
        }

        [HttpPost("{shoppingCartId}/items")]
        public async Task<IActionResult> AddItems(int shoppingCartId, [FromBody] List<ShoppingCartItemRequest> itemRequests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = _mapper.Map<List<ShoppingCartItem>>(itemRequests);

            var resultCount = await _shoppingCartService.AddItemsToShoppingCartAsync(shoppingCartId, items);

            if (resultCount > 0)
            {
                return Ok(new { Message = $"Items successfully added. Total items count: {resultCount}." });
            }

            return BadRequest("Unable to add items to the shopping cart.");
        }

        [HttpDelete("{shoppingCartId}/items/{productId}")]
        public async Task<IActionResult> DecreaseProductQuantity(int shoppingCartId, int productId)
        {
            try
            {
                var success = await _shoppingCartService.DecreaseProductQuantityAsync(shoppingCartId, productId);
                if (success)
                {
                    return Ok(new { Message = "The product quantity was decreased successfully." });
                }

                return BadRequest("Failed to decrease the product quantity.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("{shoppingCartId}")]
        public async Task<IActionResult> GetShoppingCart(int shoppingCartId)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartByIdAsync(shoppingCartId);
            if (shoppingCart == null)
            {
                return NotFound($"Shopping cart with ID {shoppingCartId} not found.");
            }

            var shoppingCartResponse = _mapper.Map<ShoppingCartResponse>(shoppingCart);
            return Ok(shoppingCartResponse);
        }



        [HttpDelete("{shoppingCartId}")]
        public async Task<IActionResult> DeleteShoppingCart(int shoppingCartId)
        {
            var success = await _shoppingCartService.DeleteShoppingCartAsync(shoppingCartId);
            if (success==0)
            {
                return NotFound($"Shopping cart with ID {shoppingCartId} not found or already deleted.");
            }

            return NoContent();
        }
    }
}
