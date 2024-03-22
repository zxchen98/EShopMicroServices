using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Models.RequestModels
{
    public class OrderRequest
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ShipperId { get; set; }
    }
}
