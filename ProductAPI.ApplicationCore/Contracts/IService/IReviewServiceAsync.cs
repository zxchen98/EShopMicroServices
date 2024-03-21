using ProductAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.ApplicationCore.Contracts.IService
{
    public interface IReviewServiceAsync
    {
        Task<int> CreateReviewAsync(Review review);
        Task<int> UpdateReviewAsync(Review review);
        Task<int> DeleteReviewAsync(int id);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<IEnumerable<Review>> GetReviewsByProductAsync(int productId);
    }
}
