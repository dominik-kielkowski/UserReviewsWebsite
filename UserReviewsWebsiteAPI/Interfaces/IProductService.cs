using Microsoft.AspNetCore.Mvc;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;

namespace UserReviewsWebsiteAPI.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProduct(ProductDto createProduct);
        Task<Product> DeleteProduct(int id);
        Task<Product> GetProduct(int id);
        Task<PageResult<Product>> GetProducts(ProductQuery query);
        Task<Product> UpdateProduct(int id, ProductDto updateProduct);
    }
}