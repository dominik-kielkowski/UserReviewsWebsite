using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        public PageResult<Product> GetProducts(ProductQuery query)
        {
            var baseQuery = _db.Products.Include(p => p.Reviews).Where(p => query.SearchPhrase == null ||
            (p.Name.ToLower().Contains(query.SearchPhrase.ToLower())));

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var colummsSelector = new Dictionary<string, Expression<Func<Product, object>>>
                {
                    {nameof(Product.Name), r => r.Name },
                    {"Score", r => r.Reviews.Average(r => r.Score) }
                };

                var selectedColumn = colummsSelector[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var products = baseQuery.Skip(query.PageSize * (query.PageNumber -1)).Take(query.PageSize).ToList();

            if(products == null)
            {
                throw new NotFoundException("Products not found");
            }

            var totalItemsCount = baseQuery.Count();

            var result = new PageResult<Product>(products, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
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
                ImagePath = createProduct.ImagePath
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
