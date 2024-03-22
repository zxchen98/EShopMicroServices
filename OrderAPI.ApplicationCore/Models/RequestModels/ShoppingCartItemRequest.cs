using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Models.RequestModels
{
    public class ShoppingCartItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
