using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public int CustomerId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ShipperId {  get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
