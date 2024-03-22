using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal Price {  get; set; }

        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
