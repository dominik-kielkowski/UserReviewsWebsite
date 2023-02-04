using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using UserReviewsWebsiteAPI.Dtos;
using UserReviewsWebsiteAPI.Interfaces;

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
        public async Task<ActionResult<PageResult<Product>>> GetProductsAsync([FromQuery]ProductQuery query)
        {
            var product = await _service.GetProducts(query);
            return product;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var product = await _service.GetProduct(id);
            return product;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> AddProduct(ProductDto product)
        {
            var task = await _service.AddProduct(product);
            return Ok(task);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, ProductDto product)
        {
            var task = await _service.UpdateProduct(id, product);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var task = await _service.DeleteProduct(id);
            return Ok(task);
        }
    }
}
