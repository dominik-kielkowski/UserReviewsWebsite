using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IProductService
    {
        Task AddProduct(ProductDto createProduct);
        Task DeleteProduct(int id);
        Task<Product> GetProduct(int id);
        Task<PageResult<Product>> GetProducts(ProductQuery query);
        Task UpdateProduct(int id, ProductDto updateProduct);
    }
}