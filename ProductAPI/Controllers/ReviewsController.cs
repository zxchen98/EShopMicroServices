using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.ApplicationCore.Contracts.IService;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Models.RequestModel;
using ProductAPI.ApplicationCore.Models.ResponseModel;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewServiceAsync _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewServiceAsync reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewRequest reviewRequest)
        {
            var review = _mapper.Map<Review>(reviewRequest);
            var reviewId = await _reviewService.CreateReviewAsync(review);
            if (reviewId > 0)
            {
                var reviewResponse = _mapper.Map<ReviewResponse>(review);
                return CreatedAtAction(nameof(GetReview), new { id = reviewId }, reviewResponse);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review != null)
            {
                var reviewResponse = _mapper.Map<ReviewResponse>(review);
                return Ok(reviewResponse);
            }

            return NotFound();
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetReviewsByProduct(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductAsync(productId);
            var reviewResponses = _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
            return Ok(reviewResponses);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            var reviewResponses = _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
            return Ok(reviewResponses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewRequest reviewRequest)
        {
            var review = _mapper.Map<Review>(reviewRequest);
            review.Id = id;
            await _reviewService.UpdateReviewAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
