using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using UserReviewsWebsiteAPI.Interfaces;

namespace UserReviewsWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var reviews = await _service.GetReviews();

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsWithId(int id)
        {
            var reviews = await _service.GetReviewsWithId(id);

            return Ok(reviews);
        }

        [HttpPost]
        public async Task<ActionResult<Review>> AddReview(ReviewDto createReview)
        {
            var review = await _service.AddReview(createReview);

            return review;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Review>> UpdateReview(int id, ReviewDto updateReview)
        {
            var review = await _service.UpdateReview(id, updateReview);

            return review;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Review>> DeleteReview(int id)
        {
            var review = await _service.DeleteReview(id);

            return review;
        }
    }
}
