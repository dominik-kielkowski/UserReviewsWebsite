using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using UserReviewsWebsiteAPI.Services;

namespace UserReviewsWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync([FromQuery]ProductQuery query)
        {
            Task<PageResult<Product>> product = _service.GetProducts(query);
            return Ok(await product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductAsync(int id)
        {
            Task<Product> product = _service.GetProduct(id);
            return Ok(await product);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct(ProductDto product)
        {
            _service.AddProduct(product);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateProduct(int id, ProductDto product)
        {
            _service.UpdateProduct(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int id)
        {
            _service.DeleteProduct(id);
            return Ok();
        }
    }
}
