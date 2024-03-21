using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.ApplicationCore.Models.RequestModel
{
    public class ReviewRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
