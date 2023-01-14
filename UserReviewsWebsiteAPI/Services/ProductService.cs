using Microsoft.EntityFrameworkCore;
using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Database.Models;
using UserReviewsWebsiteAPI.Database.Models.Dtos;
using UserReviewsWebsiteAPI.Exceptions;

namespace UserReviewsWebsiteAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = _db.Products.Include(r => r.Reviews).ToList();

            if(products == null)
            {
                throw new NotFoundException("Products not found");
            }

            return products;
        }

        public Product GetProduct(int id)
        {
            Product product = _db.Products.FirstOrDefault(r => r.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            return product;
        }

        public void AddProduct(ProductDto createProduct)
        {
            Product product = new Product
            {

                Name = createProduct.Name,
                Description = createProduct.Description,
                ImagePath = createProduct.ImagePath,
                AverageScore = createProduct.AverageScore,
            };

            _db.Products.Add(product);
            _db.SaveChanges();

        }

        public void UpdateProduct(int id, ProductDto updateProduct)
        {
            Product product = _db.Products.FirstOrDefault(r => r.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            product.Name = updateProduct.Name;
            product.Description = updateProduct.Description;
            product.AverageScore = updateProduct.AverageScore;
            product.ImagePath = updateProduct.ImagePath;

            _db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = _db.Products.FirstOrDefault(r => r.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}
