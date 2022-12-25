using Microsoft.EntityFrameworkCore;
using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Database.Models;
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
            List<Product> products = _db.Products.ToList();

            if(products == null)
            {
                throw new NotFoundException("Products not found");
            }

            return products;
        }

        public Product GetProduct(int id)
        {
            Product product = _db.Products.Include(r => r.Category).FirstOrDefault(r => r.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            return product;
        }

        public void AddProduct(Product createProduct)
        {
            var category = _db.Categories.FirstOrDefault(r => r.CategoryId == createProduct.Category.CategoryId);

            Product product = new Product
            {

                Name = createProduct.Name,
                Description = createProduct.Description,
                ImagePath = createProduct.ImagePath,
                AverageScore = createProduct.AverageScore,
                Category = category
            };

            _db.Products.Add(product);
            _db.SaveChanges();

        }

        public void UpdateProduct(int id, Product updateProduct)
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
