using ApplicationCore.Contracts.IRepository;
using ApplicationCore.Contracts.IService;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync _customerRepository;

        public CustomerServiceAsync(ICustomerRepositoryAsync customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> CreateCustomerAsync(Customer customer)
        {
            return await _customerRepository.InsertAsync(customer);
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> FilterCustomersAsync(Expression<Func<Customer, bool>> filter)
        {
            return await _customerRepository.Filter(filter);
        }

    }
}
