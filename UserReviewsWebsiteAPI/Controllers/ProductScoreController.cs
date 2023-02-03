using Microsoft.AspNetCore.Mvc;
using UserReviewsWebsiteAPI.Interfaces;

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
        public async Task<ActionResult<double>> GetAveregeScore(int id)
        {
            var score = await _sevice.GetAveregeScore(id);
            return score;
        }
    }
}
