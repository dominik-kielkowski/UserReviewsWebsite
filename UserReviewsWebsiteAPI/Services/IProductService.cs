using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IProductService
    {
        void AddProduct(ProductDto createProduct);
        void DeleteProduct(int id);
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        void UpdateProduct(int id, ProductDto updateProduct);
    }
}