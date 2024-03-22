using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Contracts.IService
{
    public interface IOrderServiceAsync
    {
        Task<int> CreateOrderAsync(Order order);
        Task<int> UpdateOrderAsync(Order order);
        Task<int> DeleteOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> FilterOrdersAsync(Expression<Func<Order, bool>> filter);
    }
}
