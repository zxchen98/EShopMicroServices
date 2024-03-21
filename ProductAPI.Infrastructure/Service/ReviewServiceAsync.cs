using ProductAPI.ApplicationCore.Contracts.IRepository;
using ProductAPI.ApplicationCore.Contracts.IService;
using ProductAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Infrastructure.Service
{
    public class ReviewServiceAsync : IReviewServiceAsync
    {
        private readonly IReviewRepositoryAsync _reviewRepository;

        public ReviewServiceAsync(IReviewRepositoryAsync reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<int> CreateReviewAsync(Review review)
        {
            return await _reviewRepository.InsertAsync(review);
        }

        public async Task<int> UpdateReviewAsync(Review review)
        {
            await _reviewRepository.UpdateAsync(review);
            return review.Id;
        }

        public async Task<int> DeleteReviewAsync(int id)
        {
            await _reviewRepository.DeleteAsync(id);
            return id;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductAsync(int productId)
        {
            return await _reviewRepository.GetReviewsByProductAsync(productId);
        }

    }

}
