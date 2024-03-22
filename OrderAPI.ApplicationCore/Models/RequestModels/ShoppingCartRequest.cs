using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Models.RequestModels
{
    public class ShoppingCartRequest
    {
        public List<ShoppingCartItemRequest> Items { get; set; } = new List<ShoppingCartItemRequest>();
    }
}
