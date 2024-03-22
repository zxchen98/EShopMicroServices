using OrderAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Models.ResponseModels
{
    public class ShoppingCartResponse
    {
        public int Id { get; set; }
        public List<ShoppingCartItemResponse> Items { get; set; } = new List<ShoppingCartItemResponse>();
        public decimal Price { get; set; }
    }
}
