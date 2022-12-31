using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserReviewsWebsiteAPI.Database.Models;
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
        public ActionResult GetReviews()
        {
            IEnumerable<Review> reviews = _service.GetReviews();

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public ActionResult GetReview(int id)
        {
            IEnumerable<Review> review = _service.GetReview(id);

            return Ok(review);
        }

        [HttpPost]
        public ActionResult AddReview(Review createReview)
        {
            _service.AddReview(createReview);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateReview(int id, Review updateReview)
        {
            _service.UpdateReview(id, updateReview);

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteReview(int id)
        {
            _service.DeleteReview(id);

            return Ok();
        }
    }
}
