using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using UserReviewsWebsiteAPI.Services;

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
        public async Task<ActionResult> GetReviews()
        {
            IEnumerable<Review> reviews = await _service.GetReviews();

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReview(int id)
        {
            IEnumerable<Review> review = await _service.GetReview(id);

            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> AddReview(ReviewDto createReview)
        {
            await _service.AddReview(createReview);

            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReview(int id, ReviewDto updateReview)
        {
            await _service.UpdateReview(id, updateReview);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            await _service.DeleteReview(id);

            return Ok();
        }
    }
}
