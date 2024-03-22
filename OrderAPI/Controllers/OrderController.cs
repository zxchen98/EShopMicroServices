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
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderServiceAsync orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            var result = await _orderService.CreateOrderAsync(order);

            if (result > 0)
            {
                var orderResponse = _mapper.Map<OrderResponse>(order);
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, orderResponse);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            var orderResponse = _mapper.Map<OrderResponse>(order);
            return Ok(orderResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            var orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            return Ok(orderResponses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderRequest orderRequest)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            _mapper.Map(orderRequest, order);
            await _orderService.UpdateOrderAsync(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var success = await _orderService.DeleteOrderAsync(id);
            if (success==0)
                return NotFound();

            return NoContent();
        }
    }
}
