using Microsoft.EntityFrameworkCore;
using ProductAPI.ApplicationCore.Contracts.IRepository;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Repository
{
    public class ReviewRepositoryAsync : BaseRepositoryAsync<Review> , IReviewRepositoryAsync
    {
        public ReviewRepositoryAsync(ProductDbContext tb) : base(tb)
        {
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductAsync(int productId)
        {
            return await _context.Reviews
                              .Where(r => r.ProductId == productId)
                              .ToListAsync();
        }
    }
}
