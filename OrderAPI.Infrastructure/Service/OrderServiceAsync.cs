using OrderAPI.ApplicationCore.Contracts.IRepository;
using OrderAPI.ApplicationCore.Contracts.IService;
using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Service
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync _orderRepository;

        public OrderServiceAsync(IOrderRepositoryAsync orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> CreateOrderAsync(Order order)
        {

            return await _orderRepository.InsertAsync(order);
        }

        public async Task<int> UpdateOrderAsync(Order order)
        {

            return await _orderRepository.UpdateAsync(order);
        }

        public async Task<int> DeleteOrderAsync(int orderId)
        {

            return await _orderRepository.DeleteAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId);
        }

        public async Task<IEnumerable<Order>> FilterOrdersAsync(Expression<Func<Order, bool>> filter)
        {
            return await _orderRepository.Filter(filter);
        }

    }
}
