using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.IService
{
    public interface ICustomerServiceAsync
    {
        Task<int> CreateCustomerAsync(Customer customer);
        Task<int> UpdateCustomerAsync(Customer customer);
        Task<int> DeleteCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> FilterCustomersAsync(Expression<Func<Customer, bool>> filter);
    }
}
