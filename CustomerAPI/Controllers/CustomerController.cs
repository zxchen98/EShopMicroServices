using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using AutoMapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServiceAsync _customerService;
        private readonly IMapper _mapper;

        public CustomerController(CustomerServiceAsync customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                var customerResponseModels = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResponseModel>>(customers);
                return Ok(customerResponseModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomer(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                var customerResponseModel = _mapper.Map<Customer, CustomerResponse>(customer);
                return Ok(customerResponseModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> CreateCustomer(CustomerRequest customerRequestModel)
        {
            try
            {
                var customerEntity = _mapper.Map<CustomerRequest, Customer>(customerRequestModel);
                var newCustomer = await _customerService.CreateCustomerAsync(customerEntity);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
