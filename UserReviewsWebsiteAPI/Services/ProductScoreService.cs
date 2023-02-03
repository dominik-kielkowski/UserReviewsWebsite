using Microsoft.EntityFrameworkCore;
using UserReviewsWebsiteAPI.Database.Data;
using UserReviewsWebsiteAPI.Interfaces;

namespace UserReviewsWebsiteAPI.Services
{
    public class ProductScoreService : IProductScoreService
    {
        private readonly ApplicationDbContext _db;

        public ProductScoreService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<double> GetAveregeScore(int productId)
        {
            if (await _db.Reviews.Where(x => x.ProductId == productId).AnyAsync())
            {
                var averege = await _db.Reviews.Where(x => x.ProductId == productId).AverageAsync(x => x.Score);
                averege = Math.Round(averege, 1);
                return averege;
            }

            return 0;
        }
    }
}
