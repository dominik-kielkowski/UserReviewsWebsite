using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IProductService
    {
        void AddProduct(ProductDto createProduct);
        void DeleteProduct(int id);
        Task<Product> GetProduct(int id);
        Task<PageResult<Product>> GetProducts(ProductQuery query);
        void UpdateProduct(int id, ProductDto updateProduct);
    }
}