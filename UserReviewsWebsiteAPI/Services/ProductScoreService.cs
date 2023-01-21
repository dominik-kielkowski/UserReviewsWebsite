using UserReviewsWebsiteAPI.Database.Data;

namespace UserReviewsWebsiteAPI.Services
{
    public class ProductScoreService : IProductScoreService
    {
        private readonly ApplicationDbContext _db;

        public ProductScoreService(ApplicationDbContext db)
        {
            _db = db;
        }

        public double GetAveregeScore(int productId)
        {
                var averege = _db.Reviews.Where(x => x.ProductId == productId).Average(x => x.Score);
                averege = Math.Round(averege, 1);
                return averege;
        }


    }
}
