using UserReviewsWebsiteAPI.Database.Models;

namespace UserReviewsWebsiteAPI.Services
{
    public interface IProductService
    {
        void AddProduct(Product createProduct);
        void DeleteProduct(int id);
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        void UpdateProduct(int id, Product updateProduct);
    }
}