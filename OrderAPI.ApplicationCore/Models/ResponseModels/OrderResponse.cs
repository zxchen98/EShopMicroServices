using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Models.ResponseModels
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ShipperId { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
