using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserReviewsWebsiteAPI.Services;

namespace UserReviewsWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductScoreController : ControllerBase
    {
        private IProductScoreService _sevice;

        public ProductScoreController(IProductScoreService service)
        {
            _sevice = service;
        }

        [HttpGet("{id}")]
        public ActionResult GetAveregeScore(int id)
        {
            var score = _sevice.GetAveregeScore(id);
            return Ok(score);
        }
    }
}
